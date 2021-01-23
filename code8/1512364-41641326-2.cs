    public Form1()
        {
            //...
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new bw_RunWorkerCompleted; //new listener event
        }
