    using (var context = new YourContext())
    {
        var mathClass= new Class { Name = "Math" };
        Student student1 = context.Students.FirstOrDefault(s => s.Name == "Alice");
        Student student2 = context.Students.FirstOrDefault(s => s.Name == "Bob");
        mathClass.Students.Add(student1);
        mathClass.Students.Add(student2);
    
        context.AddToClasses(mathClass);
        context.SaveChanges();
    }
