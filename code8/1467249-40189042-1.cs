        private  void Button_Click_1(object sender, EventArgs e)
        {
            int i = 5;
            Task.Run(() => Process(ref i)).Wait();
          
            MessageBox.Show("From button_click: "+i.ToString());
        }
        public void Process(ref int w)
        {
                MessageBox.Show("From task-1: "+ w.ToString());
                w++;
                MessageBox.Show("From task-2: " + w.ToString());
        }        
    
