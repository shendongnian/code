    using System;
    using System.Linq;
    using System.IO;
    using System.Xml;
    using System.Net;
    using HtmlAgilityPack;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var wc = new WebClient();
    		wc.BaseAddress = "http://sat24.com/";
    		HtmlDocument doc = new HtmlDocument();
    		
    		var temp = wc.DownloadData("/en");
    		doc.Load(new MemoryStream(temp));		
    		
    		var secTokenScript = doc.DocumentNode.Descendants()
    			.Where(e =>
    				   String.Compare(e.Name, "script", true) == 0 &&
    				   String.Compare(e.ParentNode.Name, "div", true) == 0 &&
    				   e.InnerText.Length > 0 &&
    				   e.InnerText.Trim().StartsWith("var region")
    				  ).FirstOrDefault().InnerText;
    		var securityToken = secTokenScript;
    		securityToken = securityToken.Substring(0, securityToken.IndexOf("arrayImageTimes.push"));	
    		securityToken = secTokenScript.Substring(securityToken.Length).Replace("arrayImageTimes.push('", "").Replace("')", "");
    		var dates = securityToken.Trim().Split(new string[] { ";"}, StringSplitOptions.RemoveEmptyEntries);
    		var scriptDates = dates.Select(x => new ScriptDate { DateString = x });
    		foreach(var date in scriptDates) 
    		{
    			Console.WriteLine("Date String: '" + date.DateString + "'\tYear: '" + date.Year + "'\t Month: '" + date.Month + "'\t Day: '" + date.Day + "'\t Hours: '" + date.Hours + "'\t Minutes: '" + date.Minutes + "'");
    		}
    		
    	}
    	
    	
    	public class ScriptDate
    	{
    		public string DateString {get;set;}
    		public int Year 
    		{
    			get
    			{
    				return Convert.ToInt32(this.DateString.Substring(0, 4));
    			}
    		}
    		public int Month
    		{
    			get
    			{
    				return Convert.ToInt32(this.DateString.Substring(4, 2));
    			}
    		}
    		public int Day
    		{
    			get
    			{
    				return Convert.ToInt32(this.DateString.Substring(6, 2));
    			}
    		}
    		public int Hours
    		{
    			get
    			{
    				return Convert.ToInt32(this.DateString.Substring(8, 2));
    			}
    		}
    		public int Minutes
    		{
    			get
    			{
    				return Convert.ToInt32(this.DateString.Substring(10, 2));
    			}
    		}
    		
    		
    				
    			
    	}
    	
    	
    }
