<!-- -->
     private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("this is it");
                //e.IsInputKey = true;
            }
        }
