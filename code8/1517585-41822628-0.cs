    public class MyClass
    {
        StringBuilder SB;
        public string ObtainString()
        {
            // This is executed, but takes lot of time/times out
            // Possible solution below
            SB = new StringBuilder();
            DateTime dt = DateTime.Now;
            bool isRead = false;
            while(DateTime.Now.Add(20) > dt) && !isRead)
            {
                string helpVar = ReadPartOfFileOrBuffer();
                SB.Append(helpVar);
                isRead = checkIfFileOrBufferIsRead();
            };
            
            if(!isRead) throw new Exception("Read timed out");
            return SB.ToString();
        }
        public voic Commit(string s)
        {
            //This is not being executed!
        }
        public void Do()
        {
            string result = ObtainString();
            Commit(result);
        }
