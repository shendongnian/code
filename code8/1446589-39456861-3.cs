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
    	
    	public static void SendEmail(string subject, string body) //add a third param if you want to pass List<T> of Email Address then use `.Join()` method to join the List<T> with a `emailaddr + | emailAddr` etc.. the Join will append the `|` for you if tell look up how to use List<T>.Join() Method
    	{
    		using (var client = new SmtpClient(utilities.EmailHost, 25)) 
    		using (var message = new MailMessage()
    		{
    			From = new MailAddress(utilities.FromEmail),
    			Subject = subject,
    			Body = body
    		})
    		{
                //client.EnableSsl = true; //uncomment if you really use SSL
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client.Credentials = new NetworkCredential(fromAddress, fromPassword);    
    			foreach (var address in utilities.EmailRecips.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
    				message.To.Add(address);
    			client.Send(message);
    		}
    	}
    }
