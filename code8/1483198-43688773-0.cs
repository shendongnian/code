    frameChanger.Navigate(new framePrenotation(frameChanger));`
...
    public partial class framePrenotation: Page
    {
       private Frame frameParent; 
       public framePrenotation(Frame frame)
       {
          this.frameParent= frame;
          ...
       }
       ...
    }
