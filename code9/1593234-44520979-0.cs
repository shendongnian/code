    public class Person 
    {
    	public int PersonCode { get; set; }
    	public string Surname { get; set; }
    	public string Name { get; set; }
    	public string Address { get; set; }
    
    	//constructor, etc.
    
    	public override string ToString()
    	{
    		return string.Format("{0} {1} {2} {3}", PersonCode, Surname, Name, Address);
    	}
       
    }
    public class Absence 
    { 
    	public int AbsenceCode { get; set; }
    	public int TypeAbsence { get; set; }
    	public DateTime StartingDate { get; set; }
    	public DateTime EndingDate { get; set; }
    	public string Description { get; set; }
    	public string State { get; set; }
    	//"a link" to person
    	public Person Person { get; set; }
    	
    	//constructor, etc.
    	
        public override string ToString()
        {
            return string.Format("{0}\t|\t{1}\t{2}\t{3}", Person.ToString(), TypeAbsence.ToString(), 
	    		StartingDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
		    	EndingDate.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
