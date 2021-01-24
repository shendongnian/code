    private static void button_Click(object sender, RoutedEventArgs e)
    {
       Button btn = (Button)sender; 
       int row = Grid.GetRow(btn);
       TextBox txtBox = SampleGrid.Children
          .OfType<TextBox>()
          .First(txt => txt.Name == name && Grid.GetRow(txt) == row);
       // ...
    }
