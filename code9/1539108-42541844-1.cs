    class TalkingBot
    {
        string input = null;
        int timeout = 0;
        string asyncThnikResult = null;
        public string Think(string input, int timeout)
        {
            DateTime timeLimit = DateTime.Now.AddMilliseconds(timeout);
            this.input  = input;
            this.timeout = timeout;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(AsyncThnik));
            thread.Start();
            //wait for result, in this case 
            while (string.IsNullOrEmpty(asyncThnikResult))
            {
                if (timeLimit <= DateTime.Now)
                {
                    throw new Exception("Timeout occured!");
                }
                System.Threading.Thread.Sleep(10);
            }
            //return result...
            return this.asyncThnikResult;
        }
        /// <summary>
        /// Do your thing async...
        /// </summary>
        void AsyncThnik()
        {
            string temp = "This value will never be returned due to timeout limit...";
            System.Threading.Thread.Sleep(timeout + 1000);  //add second to produce timeout...
            this.asyncThnikResult = temp;
        }
    }
