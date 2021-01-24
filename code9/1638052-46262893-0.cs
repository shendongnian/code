       sp.Children.Add(new TextBlock { Text = s.Model + " " + s.Date.Value.ToShortDateString() });
       Button btn = new Button { Content = "Удалить", Width = 55, Height = 20, FontSize = 13 }
       btn.Click += Btn_Click;
       sp.Children.Add(btn);
       //rest of your code
    }
    private void Btn_Click(object sender, RoutedEventArgs e)
    {
       DeleteSale(Sale sale); // pass your method here appropriately
    }
