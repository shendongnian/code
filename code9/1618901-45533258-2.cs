    public class PresenterA : IReceiver<EventArgs>, IDisposable
       {
           readonly IMessanger messanger;
     
           public PresenterA(IMessanger messanger)
           {
               this.messanger = messanger;
               this.messanger.Subscribe(this, (int)PubSubMsg.AppInstl);
           }
     
           public void Receive(object sender, EventArgs e, int messageId)
           {
               if ((PubSubMsg)messageId == PubSubMsg.AppInstl)
               {
                   //Now that you received the message, update the UI, etc...
               }
           }
     
           public void Dispose()
           {
               this.messanger.Unsubscribe(this, (int)PubSubMsg.AppInstl);
           }
       }
     
       public class PresenterB
       {
           readonly IMessanger messanger;
     
           public PresenterB(IMessanger messanger)
           {
               this.messanger = messanger;
           }
     
           public void btnApplicationRemove(object sender, EventArgs e)
           {
               //Do what you need to do and then publish the message
               this.messanger.Publish<EventArgs>(this, e, (int)PubSubMsg.AppInstl);
           }
       }
     
       public enum PubSubMsg
       {
           AppInstl = 1
       }
    
     
