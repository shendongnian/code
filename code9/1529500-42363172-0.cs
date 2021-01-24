    <Query Kind="Program">
      <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
      <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
      <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Queryable.dll</Reference>
      <NuGetReference>Faker</NuGetReference>
      <NuGetReference>mongocsharpdriver</NuGetReference>
      <NuGetReference>MongoDB.Driver</NuGetReference>
      <NuGetReference>NBuilder</NuGetReference>
      <NuGetReference>Newtonsoft.Json</NuGetReference>
      <NuGetReference>System.Linq.Dynamic</NuGetReference>
      <Namespace>FizzWare.NBuilder</Namespace>
      <Namespace>MongoDB.Bson</Namespace>
      <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
      <Namespace>MongoDB.Driver</Namespace>
      <Namespace>MongoDB.Driver.Builders</Namespace>
      <Namespace>MongoDB.Driver.Linq</Namespace>
      <Namespace>myAlias = System.Linq.Dynamic</Namespace>
      <Namespace>Newtonsoft.Json</Namespace>
      <Namespace>System.Linq</Namespace>
      <Namespace>System.Linq.Expressions</Namespace>
      <Namespace>System.Threading.Tasks</Namespace>
      <Namespace>System.Threading.Tasks.Dataflow</Namespace>
    </Query>
    
    private string _mongoDBConnectionString = "mongodb://localhost";
    private string _mongoDBDatabase = "LinqToQ";
    private string _mongoDBCollection = "People";
    
    private IMongoClient _mongoClient;
    private IMongoDatabase _mongoDb;
    
    private int _demoCount = 2000000;
    private bool _doPrep = false;
    
    void Main()
    {
    	_connectToMongoDB();
    
    	// Should demo data be generated
    	if (_doPrep)
    		_prepMongo();
    
    	// Get the queryable to test with
    	var mongoDataQuery = _getIQueryable();
    	// Print the original expression	
    	//mongoDataQuery.Expression.ToString().Dump("Original Expression");
    
    	// Evaluate the expression and try find the where expression
    	var whereFinder = new WhereFinder<Person>(mongoDataQuery.Expression);
    
    	// Get the MongoCollection to be Filtered and Count
    	var tempColl = _getPeopleCollection();
    
    	if (whereFinder.FoundWhere)
    	{
    		//whereFinder.TheWhereExpression.ToString().Dump("Calculated where expression");
    		var filter = new FilterDefinitionBuilder<Person>();
    		var stopwatch = new Stopwatch();
    		stopwatch.Start();
    		tempColl.Count(filter.Where(whereFinder.TheWhereExpression)).Dump("Dynamic where count");
    		var afterCalculatedWhere = stopwatch.Elapsed;
    		mongoDataQuery.Count().Dump("IQueryable<T> where count");
    		var afterIQuerableWhere = stopwatch.Elapsed;
    		stopwatch.Stop();
    
    		$"Calculated where:{afterCalculatedWhere:c}\nIQueryable where:{afterIQuerableWhere:c}".Dump("Where Durations");
    	}
    	else
    		tempColl.Count(FilterDefinition<Person>.Empty).Dump("No filter count");
    
    	"Done".Dump();
    }
    
    ///////////////////////////////////////////////////////
    // END SOLUTION
    ///////////////////////////////////////////////////////
    private IMongoQueryable<Person> _getIQueryable()
    {
    	var people = _getPeopleCollection();
    
    	//return people.AsQueryable().Where(p => p.DateOfBirth <= new DateTime(1974, 1, 1));
    	return people.AsQueryable().Where(p => p.LastName == "Anderson" && p.FirstName.Contains("f") && p.DateOfBirth >= new DateTime(1968, 1, 1) && p.DateOfBirth < new DateTime(1974, 1, 1));
    	//return people.AsQueryable().Where(p => p.LastName == "Anderson" && p.FirstName.Contains("f") && (p.DateOfBirth>=new DateTime(1968,1,1) && p.DateOfBirth<new DateTime(1974,1,1)));
    	//return people.AsQueryable().Where(p => p.LastName == "Anderson" && p.FirstName.Contains("f"));
    	//return people.AsQueryable().Where(p => p.FirstName.Contains("f"));
    	//return people.AsQueryable().Where(p => p.LastName == "Anderson");
    
    }
    public class Person
    {
    	[BsonId]
    	public string Id { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public string Email { get; set; }
    	public DateTime DateOfBirth { get; set; }
    
    }
    public class WhereFinder<T> : MongoDB.Driver.Linq.ExpressionVisitor
    {
    	private bool _processingWhere = false;
    	private bool _processingLambda = false;
    	public ParameterExpression _parameterExpression { get; set; }	
    
    	public WhereFinder(Expression expression)
    	{
    		Visit(expression);
    	}
    
    	public Expression<Func<T, bool>> TheWhereExpression { get; set; }
    	public bool FoundWhere
    	{
    		get { return TheWhereExpression != null; }
    	}
    
    	protected override Expression VisitBinary(BinaryExpression node)
    	{
    		var result = base.VisitBinary(node);
    		if(_processingWhere)
    			TheWhereExpression = (Expression<Func<T, bool>>)Expression.Lambda(node, _parameterExpression);
    		return result;
    	}
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		if (_processingWhere || _processingLambda || _parameterExpression==null)
    			_parameterExpression = node;
    		return base.VisitParameter(node);
    	}
    	protected override Expression VisitMethodCall(MethodCallExpression expression)
    	{
    		string methodName = expression.Method.Name;
    		if (TheWhereExpression==null && ( methodName == "Where" || methodName == "Contains"))
    		{
    			_processingWhere = true;
    			if (expression?.Arguments != null)
    				foreach (var arg in expression.Arguments)
    					Visit(arg);
    			_processingWhere = false;
            }
    				
    		return expression;
    	}
    	protected override Expression VisitLambda(LambdaExpression exp)
    	{
    		if (_parameterExpression == null)
    			_parameterExpression = exp.Parameters?.FirstOrDefault();
    			
    		TheWhereExpression = (Expression<Func<T, bool>>)Expression.Lambda(exp.Body, _parameterExpression);
    		return exp;
    	}
    	
    }
    ///////////////////////////////////////////////////////
    // END SOLUTION
    ///////////////////////////////////////////////////////
    
    
    
    ///////////////////////////////////////////////////////
    // BEGIN DEMO DATA
    ///////////////////////////////////////////////////////
    private void _prepMongo()
    {
    	_mongoDb.DropCollection(_mongoDBCollection, CancellationToken.None);
    
    	var testData = _getDemoList(_demoCount);
    	var people = _getPeopleCollection();
    
    	people.Indexes.CreateOne(Builders<Person>.IndexKeys.Ascending(_ => _.FirstName));
    	people.Indexes.CreateOne(Builders<Person>.IndexKeys.Ascending(_ => _.LastName));
    	people.Indexes.CreateOne(Builders<Person>.IndexKeys.Ascending(_ => _.Email));
    	people.Indexes.CreateOne(Builders<Person>.IndexKeys.Ascending(_ => _.DateOfBirth));
    
    	$"Inserting ...{testData.Count}... demo records".Dump();
    
    	Extensions.ForEachOverTpl<Person>(testData, (person) =>
    	{
    		people.InsertOneAsync(person).Wait();
    	});
    
    	$"Inserted {testData.Count} demo records".Dump();
    }
    private IList<Person> _getDemoList(int demoCount)
    {
    	var result = Builder<Person>.CreateListOfSize(demoCount)
    		.All()
    		.With(p => p.FirstName = Faker.NameFaker.FirstName())
    		.With(p => p.LastName = Faker.NameFaker.LastName())
    		.With(p => p.Email = Faker.InternetFaker.Email())
    		.With(p => p.DateOfBirth = Faker.DateTimeFaker.BirthDay(21, 50))
    		.Build();
    
    	return result;
    }
    private IMongoCollection<Person> _getPeopleCollection()
    {
    	return _mongoDb.GetCollection<Person>(_mongoDBCollection);
    }
    private void _connectToMongoDB()
    {
    	_mongoClient = new MongoClient(_mongoDBConnectionString);
    	_mongoDb = _mongoClient.GetDatabase(_mongoDBDatabase);
    }
    ///////////////////////////////////////////////////////
    // END DEMO DATA
    ///////////////////////////////////////////////////////
    public static class Extensions
    {
    	public static void ForEachOverTpl<T>(this IEnumerable<T> enumerable, Action<T> call)
    	{
    		var cancellationTokenSource = new CancellationTokenSource();
    		var actionBlock = new ActionBlock<T>(call, new ExecutionDataflowBlockOptions
    		{
    			TaskScheduler = TaskScheduler.Current,
    			MaxDegreeOfParallelism = Environment.ProcessorCount * 2,
    			CancellationToken = cancellationTokenSource.Token,
    		});
    		foreach (T item in enumerable)
    		{
    			if (cancellationTokenSource.IsCancellationRequested) return;
    			actionBlock.Post(item);
    		}
    		actionBlock.Complete();
    		actionBlock.Completion.Wait(cancellationTokenSource.Token);
    	}
    }
