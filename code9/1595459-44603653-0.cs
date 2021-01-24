    <TextBlock Text="{x:Bind MyText}" Style="{StaticResource SubheaderTextBlockStyle}" />
----------
    public string MyText { get; set; }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyText = "new text!!";
        Bindings.Update();
    }
