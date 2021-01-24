    static void Main(string[] args)
    {
    	var context = new AppDataContext(new DbContextOptionsBuilder<AppDataContext>().UseInMemoryDatabase("test")
    		.Options);
    
    	var category11 = new Category {Id = 11, Name = "Category-11"};
    
    	var subject22 = new Subject {Id = 22, Name = "Subject-22"};
    	subject22.Categories.Add(category11);
    
    	var mark1 = new Mark
    	{
    		Id = 1,
    		Name = "Mark-1",
    		CategoryId = 11,
    		SubjectId = 22,
    		Category = category11,
    		Subject = subject22
    	};
    
    	context.Categories.Add(category11);
    	context.Subjects.Add(subject22);
    	context.Marks.Add(mark1);
    	context.SaveChanges();
    
    	var markList = context.Marks.ToList();
    
    	foreach (var mark in markList)
    	{
    		Console.WriteLine(mark.Name);
    		Console.WriteLine(mark.Subject.Categories.FirstOrDefault().Name);
    	}
    
    	Console.ReadKey();
    }
