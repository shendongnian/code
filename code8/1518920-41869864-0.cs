    public classs Communication
    {
        // initialize every variable needed to communicate
    
        // and three more fields
        string _unfinishedLine = string.Empty;
    
        public Queue<string> LinesQueue = new Queue<string>();
    
        public event EventHandler LineAdded;
        public Communication()
        {
            ComPort.DataReceived += WhenDataReceived;
        }
    
        void WhenDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = ComPort.ReadExisting();
            string line = _unfinishedLine;
            while ( QueueMessage(ref line, message) )
            {
                LinesQueue.Enqueue(line);
                message = message.Remove(0, line.Length);
                EventHandler handler = LineAdded;
                if(handler != null)
                    handler(this, new EventArgs());
            }
            _unfinishedLine = line;
        }
    
        bool QueueMessage(ref string line, string message)
        {
            // line endings in ASCII :
            //  LF ( \n ) = 0x0A
            //  CR ( \r ) = 0x0D
            //  CR/LF ( \r\n ) = 0x0D0A
            const char LINE_ENDINGS = new char[2] { (char)0x0D, (char)0x0A };
            // now check for the line endings
            int idx = message.IndexOf(LINE_ENDINGS[0]);
            if(idx != -1)
            {
                 if(idx + 1 < message.Length && message[idx + 1] == LINE_ENDINGS[1])
                 {
                     // CR/LF line ending
                     line = message.Substring(0, idx + 2);
                 }
                 else
                 {
                     // CR line ending
                     line = message.Substring(0, idx + 1);
                 }
                 return true;
            }
            else if ( (idx = message.IndexOf[LINE_ENDINGS[1]) != -1 )
            {
                // LF line ending
                line = message.Substring(0, idx + 1);
                return true;
            }
            else
            {
                // no break line signs found.. store message and add signs to it
                line = message;
                return false;
            }
        }
    }
