    static void Main(string[] args)
    {
    	var context = new AppDataContext(new DbContextOptionsBuilder<AppDataContext>().UseInMemoryDatabase("test")
    		.Options);
    
    	var category1 = new Category {Id = 11, Name = "Category-1"};
    
    	var subject1 = new Subject {Id = 22, Name = "Subject-1"};
    	subject1.Categories.Add(category1);
    
    	var mark1 = new Mark
    	{
    		Id = 1,
    		Name = "Mark-1",
    		CategoryId = 11,
    		SubjectId = 12,
    		Category = category1,
    		Subject = subject1
    	};
    
    	context.Categories.Add(category1);
    	context.Subjects.Add(subject1);
    	context.Marks.Add(mark1);
    	context.SaveChanges();
    
    	var markList = context.Marks.ToList();
    
    	foreach (var mark in markList)
    	{
    		Console.WriteLine(mark.Name);
    		Console.WriteLine(mark.Subject.Categories.FirstOrDefault().Name);
    	}
    
    	Console.WriteLine("Hello World!");
    
    	Console.ReadKey();
    }
