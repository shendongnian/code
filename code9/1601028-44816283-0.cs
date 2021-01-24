    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    	public class TradeSequenceNo
    	{
    		private static int sequenceno;
    		public string id
    		{
    			get
    			{
    				return "NextTradeID";
    			}
    		}
    		public static int NextSequanceNo
    		{
    			get
    			{
    				sequenceno++;
    				return sequenceno;
    			}
    		}
    	}
    
    	public class Program
    	{
    		static void Main(string[] args)
    		{
    			int a1 = TradeSequenceNo.NextSequanceNo;
    			int b2 = TradeSequenceNo.NextSequanceNo;
    			System.Console.WriteLine(a1);
    			System.Console.WriteLine(b2);
    			System.Console.ReadKey();
    		}
    	}
    }
