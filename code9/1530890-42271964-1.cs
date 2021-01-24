        // ...
        TextBox tb = new TextBox();  
        tb.TextChanged += Tb_TextChanged;
        // ...
        bool _changing;
        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_changing)
                return;
            _changing = true;
            TextBox tb = (TextBox)sender;
            string tx = tb.Text;
            while (tx.Contains(" "))
                tx = tx.Replace(" ", string.Empty);
            tb.Text = tx;
            _changing = false;
        }
