    // Find the class
    Class a = db.Classes.FirtsOrDefault( x => x.ClassID == 1);
    
    // be sure it exists
    if(a != null)
    {
    	// find the student
    	Student s = db.Students.FirtsOrDefault(x => x.StudentID == 1);
    
    	// Always check if the object exist on the database, 
    	// the row could be removed from another part of your program.
    	// Otherwise you will get an error on Add() because object is null
    	if(s != null)
    	{
    		a.Students.Add(s);
    	}
    }
