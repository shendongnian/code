    private void button1_click(object sender, RoutedEventArgs e)
        {
            try {               
                port.Write("A");                
            }
            catch (Exception ex)
            {
                textbox.Text = " Send Failed !";
            }
        }
