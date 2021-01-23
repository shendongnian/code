       public static Student GetStudent(Func<Student,bool> selector)
        {
             return _context.Student.Where(selector).FirstOrDefault();
        }
    ...
        public void DoSomeWork()
        {
         var student=GetStudent(x=>x.id==123);
         student.name="Tom";
         student.Save();  // <---- is there a way to create such an extension. 
                          //Not for Student Entity only but for all entities.
        }
