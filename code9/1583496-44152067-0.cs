            using System;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var obj = new RootReq()
    		{resourceType = "Bundle", type = "message", entry = new Entry[]{new Entry()
    		{resource = new Resource()
    		{resourceType = "MessageHeader", 
    		 timestamp = Convert.ToString(DateTime.Now),
    		 id = "Test1", 
    		 _event = new Event()
    		{code = "diagnosticreport-provide"}, source = new Source()
    		{endpoint = "http://yourdomain.com/api"}, destination = new Destination[]{new Destination()
    		{endpoint = "https://api.com/api/$process-message"}}}}, new Entry()
    		{resource = new Resource()
    		{resourceType = "DiagnosticReport",
    		 timestamp = null,
    		 extension = new Extension[]{
    			new Extension()
    				
    		{url = "DiagnosticReportDefinition", extension = new Extension1[]{new Extension1()
    		{url = "useNewMedications", valueBoolean = "false"}, new Extension1()
    		{url = "providePDFReport", valueBoolean = "false"}, new Extension1()
    		{url = "returnDetectedIssues", valueBoolean = "true"}, new Extension1()
    		{url = "returnObservations", valueBoolean = "true"}, new Extension1()
    		{url = "returnMedications", valueBoolean = "true"}, new Extension1()
    		{url = "returnDosingGuidance", valueBoolean = "true"}, new Extension1()
    		{url = "includePIMTable", valueBoolean = "true"}, new Extension1()
    		{url = "includeDDIData", valueBoolean = "false"}, new Extension1()
    		{url = "reportId", valueString = ""}, }}}}}, new Entry()
    		{resource = new Resource()
    		{resourceType = "ProcedureRequest", id = "17"}}}};
    		var str = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { 
                                    NullValueHandling = NullValueHandling.Ignore
                                });
    		Console.WriteLine(str);
    	}
    }
    
    public class RootReq
    {
    	public string resourceType
    	{
    		get;
    		set;
    	}
    
    	public string type
    	{
    		get;
    		set;
    	}
    
    	public Entry[] entry
    	{
    		get;
    		set;
    	}
    }
    
    public class Entry
    {
    	public Resource resource
    	{
    		get;
    		set;
    	}
    }
    
    public class Resource
    {
    	public string resourceType
    	{
    		get;
    		set;
    	}
    
    	public String timestamp
    	{
    		get;
    		set;
    	}
    
    	public string id
    	{
    		get;
    		set;
    	}
    
    	public Event _event
    	{
    		get;
    		set;
    	}
    
    	public Source source
    	{
    		get;
    		set;
    	}
    
    	public Destination[] destination
    	{
    		get;
    		set;
    	}
    
    	public Extension[] extension
    	{
    		get;
    		set;
    	}
    }
    
    public class Event
    {
    	public string code
    	{
    		get;
    		set;
    	}
    }
    
    public class Source
    {
    	public string endpoint
    	{
    		get;
    		set;
    	}
    }
    
    public class Destination
    {
    	public string endpoint
    	{
    		get;
    		set;
    	}
    }
    
    public class Extension
    {
    	public string url
    	{
    		get;
    		set;
    	}
    
    	public Extension1[] extension
    	{
    		get;
    		set;
    	}
    }
    
    public class Extension1
    {
    	public string url
    	{
    		get;
    		set;
    	}
    
    	public string valueBoolean
    	{
    		get;
    		set;
    	}
    
    	public string valueString
    	{
    		get;
    		set;
    	}
    }
