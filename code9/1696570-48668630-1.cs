    TextBox textBox = new TextBox();
    Viewbox vb = new Viewbox();
    
    vb.Content = textbox;
    vb.Stretch = Uniform;
    textBox.Name = name;
    textBox.Text = text;
    vb.SetValue(Grid.ColumnProperty, column);
    vb.SetValue(Grid.RowProperty, row);
    vb.SetValue(Grid.ColumnSpanProperty, columnspan);
    vb.SetValue(Grid.RowSpanProperty, rowspan);
