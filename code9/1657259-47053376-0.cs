    public class AB()
    {
	    public List<T> AList { get; set; }
    	public List<T> BList { get; set; }
    }
    //code in the function
    List<AB> lstAB = new List<AB>();
    int takeA = 2;
    int takeB = 4;
    int skipA = 0;
    int skipB = 0;
    while(condition)
    {
    	lstAb.Add(new AB() 
        { 
            AList = listA.Skip(skipA).Take(takeA).ToList(), 
            BList = listB.Skip(skipB).Take(takeB).ToList()
        });
        skipA += takeA;
        skipB += takeB;
    };
