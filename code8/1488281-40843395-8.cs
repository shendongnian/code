    using System.Timers;
    public class MyClass
    {
        Timer mTimer;
        string mFilePath;
        public delegate void StatusCheck(bool value);
        public event StatusCheck StatusChecked; 
        MyClass(string filePath)
        {
            mFilePath = filePath;
            mTimer = new Timer(); //time in ms
            mTimer.Elapsed += new ElapsedEventHandler(Scan);
        }
        public void Start()
        { mTimer.Enabled=true; }
        private void Scan(object source, ElapsedEventArgs e)    
        {
            Scanner.Scan(filePath);
            ResultType result;
            if(result = Scanner.CheckStatus())
            {
                this.StatusChecked?.Invoke(result); 
            }
        }
    }
