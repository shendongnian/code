        private  void Button_Click_1(object sender, EventArgs e)
        {
            int i = 5;
            Task.Run(() => Process(i)).Wait();
          
            MessageBox.Show("From button_click: "+i.ToString());
        }
        public void Process(int w)
        {
                MessageBox.Show("From task-1: "+ w.ToString());
                w++;
                MessageBox.Show("From task-2: "+ w.ToString());
        }    
