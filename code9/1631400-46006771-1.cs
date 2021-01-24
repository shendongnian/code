            //Initially
            this.Enabled = false;
            Form form = new YourForm();
            form.TopMost = true;
            form.Focus();
            System.Threading.Thread thread = new System.Threading.Thread(() => form.ShowDialog());
            thread.Priority = System.Threading.ThreadPriority.Highest; //<- just an example, set it according to your need
            thread.Start();
            //If you want to close it from the main form (you can do it from the opened form itself though)
            form.Invoke((MethodInvoker)delegate
            {
                form.Close();
            });
            thread.Abort();
            this.TopMost = true;
            this.Enabled = true;
            this.Focus();
            this.TopMost = false;
