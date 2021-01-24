     public void showMessage(string Message)
     {
                    if(!string.IsNullOrWhiteSpace(Message))
                    textBlockMessage.Text = Message;
     }
     private void buttonWindow2_Click(object sender, RoutedEventArgs e)
     {
                // Open Window 2
                //Window2 window2 = new Window2(this);
                Window2 window2 = new Window2(showMessage);
                window2.Left = Math.Max(this.Left - window2.Width, 0);
                window2.Top = Math.Max(this.Top - 0, 0);
                window2.ShowDialog();
      }
