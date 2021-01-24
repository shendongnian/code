    //Find the class
    Class a = db.Classes.Where( x => x.ClassID == 1)
    
    //find the student
    Student s = db.Students.FirtsOrDefault( x=> x.StudentID == 1);
    
    //Allways check if the object exist on the database, 
    //the row could be removed from elsewhere of your program.
    //Otherwise you will get an error on Add(s) because s is null
    if(s != null)
    {
    	a.Students.Add(s);
    }
