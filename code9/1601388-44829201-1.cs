	public class QueryCache
	{
		private static QueryCache _instance; 
		private TypeOfQ1 _q1;
		private TypeOfQ2 _q2;
		private TypeOfQ3 _q3;
		private TypeOfQ4 _q4;
		
		protected QueryCache() {}
		
		public QueryCache Instance()
		{
			if (_instance == null)
				_instance = new QueryCache();
			return _instance
		}
		
		public Invalidate()
		{
			_instance = null;
		}
		
		public TypeOfQ1 Q1 
		{
			get
			{
				if (_q1 == null)
					_q1 = db.getData1();
				return _q1;
			}
		}
		
		public TypeOfQ2 Q2 
		{
			get
			{
				if (_q2 == null)
					_q2 = db.getData2();
				return _q2;
			}
		}
		
		public TypeOfQ3 Q3 
		{
			get
			{
				if (_q3 == null)
					_q3 = db.getData3();
				return _q3;
			}
		}
		
		public TypeOfQ4 Q4 
		{
			get
			{
				if (_q4 == null)
					_q4 = db.getData4();
				return _q4;
			}
		}
	}
	public async Task<ActionResult> GetEfficiencyValuesAsync()
	{
	  QueryCache qc = QueryCache.Instance();
	  Dictionary<string, int> model = new Dictionary<string, int>();
	  var q1 = qc.Q1;
	  var q2 = qc.Q2;
	  var q3 = qc.Q3;
	  var content = GetEfficiencyValues(q1, q2, q3);
	  model.Add("currEff", content[0]);
	  model.Add("prevEff", content[1]);
	  model.Add("otherEff", content[2]);
	  
	  return await Task.Run(() => Json(model, JsonRequestBehavior.AllowGet));
	}
	public async Task<ActionResult> GetProductivityValuesAsync()
	{
	  QueryCache qc = QueryCache.Instance();
	  Dictionary<string, int> model = new Dictionary<string, int>();
	  var q1 = qc.Q1;
	  var q2 = qc.Q2;
	  var q4 = qc.Q4;
	  content = GetProductivityValues(q1, q2, q4);
	  model.Add("currProd", content[0]);
	  model.Add("prevProd", content[1]);
	  model.Add("otherProd", content[2]);
	  
	  return await Task.Run(() => Json(model, JsonRequestBehavior.AllowGet));
	}
	public async Task<ActionResult> GetProductivityValuesAsync()
	{
	  QueryCache qc = QueryCache.Instance();
	  Dictionary<string, int> model = new Dictionary<string, int>();
	  var q1 = qc.Q1;
	  var q2 = qc.Q2;
	  var q3 = qc.Q3;
	  var q4 = qc.Q4;
	  Content = GetSlowStartValues(q1, q2, q3, q4);
	  model.Add("currAvg", content[0]);
	  model.Add("prevAvg", content[1]);
	  model.Add("otherAvg", content[2]);
	  
	  return await Task.Run(() => Json(model, JsonRequestBehavior.AllowGet));
	}
	public async Task<ActionResult> GetProductivityValuesAsync()
	{
	  QueryCache qc = QueryCache.Instance();
	  Dictionary<string, int> model = new Dictionary<string, int>();
	  var q1 = qc.Q1;
	  var q2 = qc.Q2;
	  qc.Invalidate();
	  
	  //adding WIP content for the box
	  content = GetNotSwipedInCount(q1, q2);
	  model.Add("WIP", content[0]);
	  model.Add("total", content[1]);
	  
	  return await Task.Run(() => Json(model, JsonRequestBehavior.AllowGet));
	}
