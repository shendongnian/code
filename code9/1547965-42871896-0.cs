    private void textBox_KeyUp(object sender, KeyEventArgs e)
            {
                if ((e.Key == Key.C) && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    MessageBox.Show("You have pressed control + c");
                }
    
            }
