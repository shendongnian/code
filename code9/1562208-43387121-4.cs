         public sealed class Helpers:NSObject
         {
             public LoadingOverlay LoadingOverlay;
       
             private static readonly Helpers instance = new Helpers(); 
             private Helpers(){} 
             public static Helpers Instance 
             { 
                get  
                { 
                    return instance;  
                } 
             }
 
             public void UpdateOverlayMessage(string message)
             {
                InvokeOnMainThread ( () => {
                    if(LoadingOverlay != null){
                        StackTrace stackTrace = new StackTrace();
                        System.Diagnostics.Debug.WriteLine(typeof(Helpers).Name + " (called from " + stackTrace.GetFrame(1).GetMethod().Name  + ")" + LoadingOverlay.GetHashCode());
        
                        LoadingOverlay.SetLoadingLabel(message);
                    }
                });
             }
             //So does the method "UpdateProgressValue".
         }
 
