    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// create the records
    		TestRecords testRecord1 = new TestRecords(){Id = 1, ResourceGroup = "SIP", ServerName = "win1234", CircuitId = 0, ChannelId = 1};
    		TestRecords testRecord2 = new TestRecords(){Id = 2, ResourceGroup = "SIP", ServerName = "win1234", CircuitId = 0, ChannelId = 2};
    		TestRecords testRecord3 = new TestRecords(){Id = 3, ResourceGroup = "TDM", ServerName = "win5678", CircuitId = 0, ChannelId = 35};
    		TestRecords testRecord4 = new TestRecords(){Id = 4, ResourceGroup = "TDM", ServerName = "win5678", CircuitId = 0, ChannelId = 36};
    		TestRecords testRecord5 = new TestRecords(){Id = 5, ResourceGroup = "SIP", ServerName = "win5678", CircuitId = 4, ChannelId = 47};
    		TestRecords testRecord6 = new TestRecords(){Id = 6, ResourceGroup = "TDM", ServerName = "win1234", CircuitId = 8, ChannelId = 56};
    		
    		// create an empty list of TestRecords to hold the records above
    		List<TestRecords> listTestRecords = new List<TestRecords>();
    		
    		// add records to list
    		listTestRecords.Add(testRecord1);
    		listTestRecords.Add(testRecord2);
    		listTestRecords.Add(testRecord3);
    		listTestRecords.Add(testRecord4);
    		listTestRecords.Add(testRecord5);
    		listTestRecords.Add(testRecord6);
    		
    		// group the records by ServerName
    		var resultGrouped = listTestRecords.GroupBy(x => new{x.ServerName, x.ResourceGroup}).ToList();
    		
    		// select the items you need based off of the groupings
    		var result = resultGrouped.Select(x => new{Server = x.Key.ServerName, ResourceGroup = x.Key.ResourceGroup, CountChannel = x.Count()}).ToList();
    		
    		foreach(var item in result){
    			Console.WriteLine(item.Server + " " + item.ResourceGroup + " " + item.CountChannel);
    		}
    		
    		// Result:
            //win1234 SIP 2
            //win5678 TDM 2
            //win5678 SIP 1
           // win1234 TDM 1
    	}
    }
    
    public class TestRecords
    {
    	public int Id {get;set;}
    	public string ResourceGroup {get;set;}
    	public string ServerName {get;set;}
    	public int CircuitId {get;set;}	
    	public int ChannelId {get;set;}
    }
