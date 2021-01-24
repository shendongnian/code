    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var fun = new List<Data>();
    		fun.Add(new Data() { Code ="X0000", GroupLevel=4, Group = null});
    		fun.Add(new Data() { Code ="X1000", GroupLevel=3, Group = "X0000"});
    		fun.Add(new Data() { Code ="X2000", GroupLevel=3, Group = "X0000"});
    		fun.Add(new Data() { Code ="X3000", GroupLevel=3, Group = "X0000"});
    		fun.Add(new Data() { Code ="X1100", GroupLevel=2, Group = "X1000"});
    		fun.Add(new Data() { Code ="X1200", GroupLevel=2, Group = "X1000"});
    		fun.Add(new Data() { Code ="X1300", GroupLevel=2, Group = "X1000"});
    		fun.Add(new Data() { Code ="X2100", GroupLevel=2, Group = "X2000"});
    		fun.Add(new Data() { Code ="X2200", GroupLevel=2, Group = "X2000"});
    		fun.Add(new Data() { Code ="X2300", GroupLevel=2, Group = "X2000"});
    		fun.Add(new Data() { Code ="X1110", GroupLevel=1, Group = "X1100"});
    		fun.Add(new Data() { Code ="X1120", GroupLevel=1, Group = "X1100"});
    		fun.Add(new Data() { Code ="X1111", GroupLevel=0, Group = "X1110"});
    		fun.Add(new Data() { Code ="X1112", GroupLevel=0, Group = "X1110"});
    		fun.Add(new Data() { Code ="X1113", GroupLevel=0, Group = "X1110"});
    		fun.Add(new Data() { Code ="X1114", GroupLevel=0, Group = "X1110"});
    		
    		var result = (from f1 in fun
    			         join f2 in fun on f1.Code equals (f2.Group ?? f2.Code)
    					  orderby f2.Code
    			         select f2).Select((v,i) => new Data(v,i)).ToList();
    		
    		result.ForEach(x => Console.WriteLine(x));
    	}
    	
    }
    
    public class Data
    {
    	public int Seq {get;set;}
    	public string Code {get;set;}
    	public int GroupLevel {get;set;}
    	public string Group {get;set;}
    	
    	public Data(){}
    	
    	public Data(Data v, int i)
    	{
    		Seq = i+1;
    		Code = v.Code;
    		GroupLevel = v.GroupLevel;
    		Group = v.Group;
    	}
    	
    	public override string ToString()
    	{
    		return string.Format("{3} - {0} - {1} - {2}",Code, GroupLevel,Group, Seq);
    	}
    }
