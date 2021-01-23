    public interface IEntityRepositoryProvider
	{
		IEntityRepository Get();	
	}
	public interface INotifier
	{
		void SendEmailNotification(string subject, string body, string emailAddress);
	}
	public class Notifier : INotifier
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
			ChangeMarketState(page, "Open", "market@mail.com");
		}
		public void CloseMarket(Page page)
		{
			ChangeMarketState(page, "Close", "market@mail.com");
		}	
		private void ChangeMarketState(Page page, string changeStateTo, string sendMailTo)
		{
		    var Id = page.Request["MarketId"];
		    var repository = RepositoryProvider.Get();
		    IEntity market = repository.GetById(Id);
		    if (market.state == changeStateTo)
		    {
		        if(changeStateTo == "Close")
		            throw new Exception("The market is already close!");
		        else
		            throw new Exception("The market is not open!");
		    }
		    else
		    {
		        string currentMarketState = string.empty;
		        string mailHeader = string.empty;
		        if(changeStateTo == "Close")
		            {
		               market.Close();
		               currentMarketState = market.ToString() + " has been closed.";
		               mailHeader = "market closed";
		            }
		        else
		            {
		               market.Open();
		               currentMarketState = market.ToString() + " was open.";
		               mailHeader = "market open";
		            }
		        repository.SaveChangesTo(market);
		        Notifier.SendEmailNotification(mailHeader, currentMarketState, sendMailTo);
		    }
	    }
	}
