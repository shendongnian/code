    public bool CompareValues(double value1, double value2)
    {
    	return (value1 > value2);
    }
    
    public bool CompareValues(object p1, object p2)
    {
    	try
    	{
    		if (p1 is student && p2 is student)
    		{
    			var student1 = (student)p1;
    			var student2 = (student)p2;
    			return CompareValues(student1.Marks, student2.Marks);
    		}
    		else if (p1 is Teacher && p2 is Teacher)
    		{
    			var teacher1 = (Teacher)p1;
    			var teacher2 = (Teacher)p2;
    			return CompareValues(teacher1.Salary, teacher2.Salary);
    		}
    		else
    		{
    			//can't compare different values
    			return false;
    		}
    	}
    	catch(Exception ex)
    	{
    		throw ex;
    	}            
    }
