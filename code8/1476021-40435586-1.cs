	public interface IEntityRepositoryProvider
	{
		IEntityRepository Get();	
	}
	public interface INotifier
	{
		void SendEmailNotification(string subject, string body, string emailAddress);
	}
	public class Notifier
	{
		public void SendEmailNotification(string subject,string body,string emailAddress)
		{
		    var smtpClient = new SmtpClient();
		    var message = new MailMessage();
		    message.Subject = subject;
		    message.Body = body;
		    message.To.Add(new MailAddress(emailAddress));
		    smtpClient.Send(message);
		}
	}
	public class TestEventHandlers
	{
		public IEntityRepositoryProvider RepositoryProvider { get; set; }
		public INotifier Notifier { get; set; }
		public TestEventHandlers()
		{
			RepositoryProvider = new EntityRepositoryProvider();
			Notifier = new Notifier();
		}
		public void OpenMarket(Page page)
		{
			var Id = page.Request["MarketId"];
            if (id!=null)
            { 
	            var repository = EntityRepositoryProvider.Get();
	            IEntity market = repository.GetById(Id);
	            if (market.State != "Open")
	            {
	                throw new Exception("The market is not open!");
	            }
	            else
	            {
	                market.Open();
	                repository.SaveChangesTo(market);
	                Notifier.SendEmailNotification("market open", market.ToString() + " was open.", "market@mail.com");
	            }
           	}
          	else
            {
                throw new Exception("entityId can not be null");
            }			
		}
		public void CloseMarket(Page page)
		{
			var Id = page.Request["MarketId"];
            if(id!=null)
            {
	            var repository = EntityRepositoryProvider.Get();
	            IEntity market = repository.GetById(Id);
	            if (market.State == "Close")
	            {
	                throw new Exception("The market is already close!");
	            }
	            else
	            {
	                market.Close();
	                repository.SaveChangesTo(market);
	                Notifier.SendEmailNotification("market closed", market.ToString() + " has been closed.", "market@mail.com");
	            }
	        }
            else
            {
                throw new Exception("entityId can not be null");
            }
		}		
	}
