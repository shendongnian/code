    private void func(object sender, KeyEventArgs e) {
        MessageBox.Show(e.KeyValue.ToString());
        MessageBox.Show(e.Alt.ToString());
        MessageBox.Show(e.Control.ToString());
        MessageBox.Show(e.Modifiers.ToString());
    }
