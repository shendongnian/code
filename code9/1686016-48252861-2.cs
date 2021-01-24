            ToolStrip ts; 
            ts = (ToolStrip)crystalReportViewer1.Controls[3]; 
     
            ToolStripButton printbutton = new ToolStripButton(); 
            printbutton.Image = ts.Items[1].Image; 
            ts.Items.Remove(ts.Items[1]); 
            ts.Items.Insert(1, printbutton); 
            ts.Items[1].Click += new EventHandler(this.CaptureEvent);                   
            cr = new CrystalReport1(); 
            this.crystalReportViewer1.ReportSource = cr; 
