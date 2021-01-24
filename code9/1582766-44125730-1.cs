    public class NumericCompare : IComparer<string>
    {
   	   public int Compare(string x, string y)
       {
			int input1,input2;
		
			input1=int.Parse(x.Substring(x.IndexOf('_')+1).Split('.')[0]); 
			input2= int.Parse(y.Substring(y.IndexOf('_')+1).Split('.')[0]);
       		return Comparer<int>.Default.Compare(input1,input2);
       }
    }
 
