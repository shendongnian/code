    public class utilities
    {  
    
    	public static string ConnectionString
    	{
    		get { return ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString; } //change dbconn to whatever your key is in the config file
    	} 
    	
    	public static string EmailRecips
    	{
    		get
    		{
    			return ConfigurationManager.AppSettings["EmailRecips"];//in the config file it would look like this <add key="EmailRecips" value="personA@SomeEmail.com|PersonB@SomeEmail.com|Person3@SomeEmail.com"/>
    		}
    	}	
    	
    	public static string EmailHost //add and entry in the config file for EmailHost 
    	{
    		get
    		{
    			return ConfigurationManager.AppSettings["EmailHost"];
    		}
    	}
    	
    	public static void SendEmail(string subject, string body)
    	{
    		using (var client = new SmtpClient(utilities.EmailHost, 25)) 
    		using (var message = new MailMessage()
    		{
    			From = new MailAddress(utilities.FromEmail),
    			Subject = subject,
    			Body = body
    		})
    		{
    			foreach (var address in utilities.EmailRecips.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
    				message.To.Add(address);
    			client.Send(message);
    		}
    	}
    }
