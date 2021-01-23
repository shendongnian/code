    int i = 0;
        public delegate void AsyncMethodCaller();
        private  void proc2()
        {
            Action action = () => control1.Text = (i += 1).ToString();
    
            if (control1.IsHandleCreated)
            {
                if (control1.InvokeRequired)
                {
                    control1.BeginInvoke(new AsyncMethodCaller(proc2));
                }
                else
                {
                    action.Invoke();
                }
            }
            else
            {
                MessageBox.Show("Handle creation error");
            }
        }
    
        private void proc1()
        {
            for (int i=0; i<1000; i++)
            {
                //do something
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(proc1);
            thread1.Start();
    
            Thread thread2 = new Thread(proc2);
            thread2.Start();
        }
