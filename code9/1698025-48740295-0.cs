    Window1 BasicArithmetic = new Window1();
        //Button Opens and Closes Basic Arithmetic Window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BasicArithmetic.IsVisible == false)
            {
                BasicArithmetic.Show();
            }
            else
            {
                BasicArithmetic.Hide();
            }            
            
        }
