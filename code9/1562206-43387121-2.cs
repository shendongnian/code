        public static class Helpers:NSObject
        {
            public static void UpdateOverlayMessage(string message)
            {
                InvokeOnMainThread ( () => {
                    if(LoadingOverlay != null){
                        StackTrace stackTrace = new StackTrace();
                        System.Diagnostics.Debug.WriteLine(typeof(Helpers).Name + " (called from " + stackTrace.GetFrame(1).GetMethod().Name  + ")" + LoadingOverlay.GetHashCode());
        
                        LoadingOverlay.SetLoadingLabel(message);
                    }
                });
            }
        }
