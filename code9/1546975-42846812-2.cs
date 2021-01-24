            if(thrd1 != null)
            {
                while (thrd1.IsAlive == true)
                    try
                    {
                        Thread.Sleep(50);
                        System.Windows.Forms.Application.DoEvents();
                    }
                    catch
                    {
                    }
            }
            if (thrd3 != null)
            {
                while (thrd3.IsAlive == true)
                    try
                    {
                        Thread.Sleep(50);
                        System.Windows.Forms.Application.DoEvents();
                    }
                    catch
                    {
                    }
            }
            this.btn_runGRM.Enabled = true;
            this.checkBox_Assgn.Enabled = true;
            this.checkBox_Avail.Enabled = true;
            this.checkBox_RFI.Enabled = true;
            this.checkBox_Census.Enabled = true;
        }
    
