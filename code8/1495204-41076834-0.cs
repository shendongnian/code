    Button btn = new Button();
    
    btn.Holding += Btn_Holding;
    
    btn.Click += Btn_Click;
    
    btn.PointerExited += Btn_PointerExited;
    
    
            private void Btn_PointerExited(object sender, PointerRoutedEventArgs e)
            {
                btn.Click += Btn_Click;
            }
    
            private void Btn_Click(object sender, RoutedEventArgs e)
            {
                
            }
    
            private void Btn_Holding(object sender, HoldingRoutedEventArgs e)
            {
                btn.Click -= Btn_Click;
            }
