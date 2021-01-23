    public class Communication
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
            int brcount = 0;
            while ( QueueMessage(ref line, out brcount, message) )
            {
                LinesQueue.Enqueue(line);
                message = message.Remove(0, line.Length + brcount);
                EventHandler handler = LineAdded;
                if(handler != null)
                    handler(this, new EventArgs());
            }
            _unfinishedLine = line;
        }
    
        bool QueueMessage(ref string line, out int brcount, string message)
        {
            // line endings in ASCII :
            //  LF ( \n ) = 0x0A
            //  CR ( \r ) = 0x0D
            //  CR/LF ( \r\n ) = 0x0D0A
            const char CR = (char)0x0D;
            const char LF = (char)0x0A;
            // now check for the line endings
            int idx = message.IndexOf(CR);
            if(idx != -1)
            {
                 if(idx + 1 < message.Length && message[idx + 1] == LF)
                 {
                     // CR/LF line ending
                     line = message.Substring(0, idx);
                     brcount = 2;
                 }
                 else
                 {
                     // CR line ending
                     line = message.Substring(0, idx);
                     brcount = 1;
                 }
                 return true;
            }
            else if ( (idx = message.IndexOf(LF) != -1 )
            {
                // LF line ending
                line = message.Substring(0, idx);
                brcount = 1;
                return true;
            }
            else
            {
                // no break line signs found.. store message and add signs to it
                line = message;
                brcount = 0;
                return false;
            }
        }
    }
