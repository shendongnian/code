    class ExtractImages
    {
        // shortened
        
        // inherit some EventArgs
        public class ProgressEventArgs : EventArgs
        {
             public int Percentage {get;set;}
             public string StateText {get;set;}
        }
        public event EventHandler<ProgressEventArgs> ProgressChanged;
        public void Init()
        {
            ExtractCountires();
            foreach (string cc in countriescodes)
            {
                // raise event here
                ProgressChanged?.Invoke(new ProgressChangedEventArgs {Percentage = ..., StateText = cc});
                ExtractDateAndTime("http://www.sat24.com/image2.ashx?region=" + cc);
            }
            ImagesLinks();
        }
    }
