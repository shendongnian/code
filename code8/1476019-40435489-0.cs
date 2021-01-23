    public class TestEventHandlers
    {
        public void OpenMarket(Page page)
        {
            ChangeMarketState(page, "Open", "market@mail.com");
        }
        public void CloseMarket(Page page)
        {
            ChangeMarketState(page, "Close", "market@mail.com");
        }
        private static void SendEmailNotification(string subject,string body,string emailAddress)
        {
            var smtpClient = new SmtpClient();
            var message = new MailMessage();
            message.Subject = subject;
            message.Body = body;
            message.To.Add(new MailAddress(emailAddress));
            smtpClient.Send(message);
        }
        public void ChangeMarketState(Page page, string changeStateTo, string sendMailTo)
        {
            var Id = page.Request["MarketId"];
            if(Id != null)
            {
                var repository = new EntityRepository();
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
                    SendEmailNotification(mailHeader, currentMarketState, sendMailTo);
                }
            }
            else
            {
                throw new Exception("entityId can not be null");  
            }
        }
    }
    
