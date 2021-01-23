    public String MyProperty { get; set; }
    public String Property { get; set; }
    [Serializable]
    public struct MyStuff
    {
            public string MyProperty;
    }
  
    private void MyWindow_Loaded(object sender, RoutedEventArgs e)
    {
        MyStuff stuff = new MyStuff();
        stuff.MyProperty = MyProperty;
        String json= JsonConvert.SerializeObject(stuff);
        lbuser.Content = json;
    
