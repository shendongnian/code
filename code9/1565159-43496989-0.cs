    private int? Q = 5;
   
    private void button_Click(object sender, RoutedEventArgs e)
    {
        MyClass a = new MyClass();
        a.SomeProp = Q;
        MyClass b = new MyClass();
        b.SomeProp = a.SomeProp;
        a = null;
        MessageBox.Show( b.SomeProp.ToString() ); //Outputs 5
        Q = null;
        MessageBox.Show( b.SomeProp.ToString() ); //Still outputs 5
    }
