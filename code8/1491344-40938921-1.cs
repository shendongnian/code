     public interface IWindowCloseNotifier {
            void Close(IWindowClosedArgs args);
        }
        
        public class SecondViewModel {
        
            private readonly IWindowCloseNotifier _windowCloseNotifier;
        
            public SecondViewModel(IWindowCloseNotifier windowCloseNotifier) {
              _windowCloseNotifier = windowCloseNotifier;
            }
        
            public void OnClose()
            {
               _windowCloser.Close(your args);
            }
        }
