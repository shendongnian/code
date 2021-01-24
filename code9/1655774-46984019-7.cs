        public class ProgressViewModel
        {
            public ProgressViewModel()
            {
                var model = new Model();
                model.ProgressChanged += (sender, e) => {
                    //invoke ui thread
                    Application.Current.Dispatcher.Invoke(
                      new Action(() => 
                       {
                         CreateFileProgress = e.CurrentProgress; 
                       }));
                };
            }
        }
