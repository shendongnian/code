            //Before your processing is started
            this.Enabled = false;
            Form form = new YourForm();
            form.TopMost = true;
            form.Focus();
            System.Threading.Thread thread = new System.Threading.Thread(() => form.ShowDialog());
            thread.Priority = System.Threading.ThreadPriority.Highest; //<- just an example, set it according to your need
            thread.Start();
           
            //Enter your processing code here
            //After your processing is completed
            form.Invoke((MethodInvoker)delegate
            {
                form.Close();
            });
            thread.Abort();
            this.TopMost = true;
            this.Enabled = true;
            this.Focus();
            this.TopMost = false;
