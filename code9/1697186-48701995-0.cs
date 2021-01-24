    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public class LogData
    	{
    	  public string IndexPattern {get; set;}
    	  public string Version {get;set;}
    	  public string Type1 {get; set;}
    	  public string Type2 {get; set;}
    	
    	  //here has a constructor of LogData class
    		public LogData(string indexPattern, string version, string type1, string type2){
    			IndexPattern = indexPattern;
    			Version = version;
    			Type1 = type1;
    			Type2 = type2;
    		}
    	}
    	
    	public class GridData
    	{
    	  public string Index {get; set;}
    	  public string Version {get;set;}
    	  public string Type1 {get; set;}
    	  public string Type2 {get; set;}
    		public int count {get;set;}
    		
    	  //here has a constructor of GridData class
    		public GridData(string indexPattern, string version, string type1, string type2, int count){
    			Index = indexPattern;
    			Version = version;
    			Type1 = type1;
    			Type2 = type2;
    			this.count = count;
    		}
    	}
    	
    	public static void Main(){
    		//Inputs
    		List<LogData> logList = new List<LogData>();
    		logList.Add(new LogData("1,2,4", "Ver1", "pro" , "etc" ) );
    		logList.Add(new LogData("1", "Ver2", "pro" , "etc" ) );
    		logList.Add(new LogData("2", "Ver1", "pro" , "etc" ) );
    		logList.Add(new LogData("1,2,4", "Ver1", "pro" , "etc" ) );
    		logList.Add(new LogData("1,5", "Ver2", "pro" , "set" ) );
    		
    		//Calculate the results
    		Dictionary<string, GridData> result = GetResult(logList);
    		
    		Display(result);
    	}
    	
    	//Read all data and Get result in tabular format
    	public static Dictionary<string, GridData> GetResult(List<LogData> logList){
    		
    		//Initialization of local variable
    		List<LogData> elements = new List<LogData>();
    		Dictionary<string, GridData> output = new Dictionary<string, GridData>();
    		
    		//Iterate through each input
    		foreach(LogData ld in logList){
    			LogData temp = new LogData("", "", "", "");
    			
    			//Check for multiple Indexs in one list
    			if(ld.IndexPattern.Contains(",")){
    				string[] strArr = ld.IndexPattern.Split(',');
    				
    				//Consider each index as one record; Time complexity: O(n*m) very bad
    				foreach(string s1 in strArr){
    					temp = new LogData(s1, ld.Version, ld.Type1, ld.Type2);
    					elements.Add(temp);
    				}
    			}
    				//Else record as it is
    			else{
    				elements.Add(ld);
    			}
    		}
    			//List elements contains all seperated records
    			foreach(LogData logData in elements){
    				//Create unique key by concatenating all properties into string
    				string key = logData.IndexPattern + "_" +  logData.Version +"_"+ logData.Type1 +"_"+logData.Type2;
    				
    				//Increment counter if record is already exist
    				if(output.ContainsKey(key))
    					output[key].count++;
    				else{
    					//Insert new record
    					GridData gd = new GridData(logData.IndexPattern, logData.Version, logData.Type1, logData.Type2, 1);
    					output.Add(key, gd);
    				}
    	}
    		return output;
    	}
    	
    	//Display in tabular format
    	public static void Display(Dictionary<string, GridData> output){
    		foreach(string str in output.Keys){
    			
    			Console.WriteLine(output[str].Index +"\t"+ output[str].Version +"\t"+ output[str].Type1 +"\t"+ output[str].Type2 +"\t"+ output[str].count);
    		}
    	}
    }
