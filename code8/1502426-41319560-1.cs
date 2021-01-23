    public class MyHandler
    {
       public void HandlerEvent(object sender, EventArgs e)
       {
           // Or make 'Create' method static
           using(var context = new BloggingContextFactory().Create())
           {
                     . . . 
           }
       }
    }
