     public void UpdateGuItemsAsync()
     {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 10000;
        timer.Tick += (sender, args) => 
        {
            timer.Stop();
            for (int i = 0; i < 100; i++)
            {
                Gu45Document gu45Document = new Gu45Document();
                gu45Document.Form = "EU-45";
                Gu45Documents.Add(gu45Document);
            }
        };
        timer.Start();  
     }
