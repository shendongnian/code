        public class Setup
        {
            public static bool Start()
            {
                Dispatcher dispatcher;
                if (Application.Current == null)
                    dispatcher = Dispatcher.CurrentDispatcher;
                else
                    dispatcher = Application.Current.Dispatcher;
            
                dispatcher.Invoke(AutomateApp);
                return true;
            }
            public static void AutomateApp()
            {
                Window root = null;
                foreach (PresentationSource presentationSource in PresentationSource.CurrentSources)
                {
                    root = presentationSource.RootVisual as Window;
                    if (root == null)
                        continue;
                    if ("NordVPN ".Equals(root.Title))
                        break;
                }
