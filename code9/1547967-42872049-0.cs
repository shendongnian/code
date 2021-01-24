            KeyPreview = true;
           
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == (Keys.Shift | Keys.Control))
            {
                MessageBox.Show(".");
            }
        }
