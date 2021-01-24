     private static void AllowOnlyString(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                
                if (d is TextBox)
                {
                    TextBox txtObj = (TextBox)d;
                    txtObj.TextChanged += Validation;
                    txtObj.Unloaded += Unload;
            
                }
            }
    
            private static void Unload(object sender, RoutedEventArgs e)
            {
                var x = (TextBox)sender;
                x.Unloaded -= Unload;
                x.TextChanged -= Validation;
            }
    
            private static void Validation(object sender, TextChangedEventArgs e)
            {
                {
                    TextBox txtObj = sender as TextBox;
                    if (!Regex.IsMatch(txtObj.Text, "^[a-zA-Z]*$"))
                    {
                        txtObj.BorderBrush = Brushes.Red;
                        MessageBox.Show("Only letter allowed!");
                    }
                };
            }
