    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	// Stack Overflow Question Link: http://stackoverflow.com/q/41078332/325521
    	// My Answer Link: http://stackoverflow.com/a/41113725/325521
    	// Author: Shiva Kumar
    	// Web: shiva.io
    	public static void Main()
    	{
    		var json = @"
    		{
    		  ""push"": {
    			""application_name"": ""Pushbullet"",
    			""body"": ""If you see this on your computer, Android-to-PC notifications are working!\n"",
    			""client_version"": 125,
    			""dismissable"": true,
    			""has_root"": false,
    			""icon"": ""(base64_encoded_jpeg)"",
    			""notification_id"": ""-8"",
    			""notification_tag"": null,
    			""package_name"": ""com.pushbullet.android"",
    			""source_device_iden"": ""ujpah72o0sjAoRtnM0jc"",
    			""source_user_iden"": ""ujpah72o0"",
    			""title"": ""Mirroring test"",
    			""type"": ""mirror""
    		  },
    		  ""type"": ""push""
    		}";
    		
    		Notification notification = JsonConvert.DeserializeObject<Notification>(json);
    		Console.WriteLine("PushBullet API Notification...");
    		Console.WriteLine("   App Name: {0}", notification.push.application_name);
    		Console.WriteLine("   Notification Body: {0}", notification.push.body);
    		// .... etc. you get the idea. You now have the notification in a POCO and do 
    		// whatever you want with it :)
    	}
    }
    
    
    public class Push
    {
        public string application_name { get; set; }
        public string body { get; set; }
        public int client_version { get; set; }
        public bool dismissable { get; set; }
        public bool has_root { get; set; }
        public string icon { get; set; }
        public string notification_id { get; set; }
        public object notification_tag { get; set; }
        public string package_name { get; set; }
        public string source_device_iden { get; set; }
        public string source_user_iden { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }
    
    public class Notification
    {
        public Push push { get; set; }
        public string type { get; set; }
    }
