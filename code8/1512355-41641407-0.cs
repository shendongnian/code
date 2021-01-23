    using System.Linq;
	static int Singularize(int val)
	{
	  string str=val.ToString();
	  int rslt=Enumerable.Range(0,str.Length).Select(i => str.Substring(i,1)).Select(int.Parse).Sum();
      return (rslt.ToString().Length==1) ? rslt : Singularize(rslt);
	}
