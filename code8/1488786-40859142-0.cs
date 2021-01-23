        private void button1_Click(object sender, EventArgs e)
        {
            Thread newThread= new Thread(PingIP);
            newThread.Start(); 
        }
        
        private void PingIP()
        {
            string IP = textBox1.Text;
            string[] IPBlocks = IP.Split('.');
            for (int x = 0; x < 50; x++)
            {
                System.Threading.Thread.Sleep(50);
                int IPLastBlock = Int32.Parse(IPBlocks[3]) + (x+1);
                IP = IPBlocks[0]+"."+ IPBlocks[1]+"."+ IPBlocks[2]+"."+ IPLastBlock;
                bool pingStatus = PingHost(IP);
                textBox2.Text += String.Format("{0} => {1} \r\n", IP, pingStatus);
            }
        }
