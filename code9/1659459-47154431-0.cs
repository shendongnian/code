    [assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageCustom))]
    
    namespace MobileCRM.iOS {     
    public class TabbedPageCustom : TabbedRenderer  {    
             
    public TabbedPageCustom ()   {      
                 
       TabBar.TintColor = MonoTouch.UIKit.UIColor.Black;
       TabBar.BarTintColor = MonoTouch.UIKit.UIColor.Blue;  
       TabBar.BackgroundColor = MonoTouch.UIKit.UIColor.Green;         
    }    
 
    }
    
    }
