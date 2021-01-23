            private void button1_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            e.Handled = true;  
            MessageBox.Show("button have been holded");
        }
        private void button1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("button have been tapped");
            //your code goes here
        }
