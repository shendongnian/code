    public class Foo
    { 
        public Foo(int val)
        {
         //Do something with val
        }
    }
    
    //for-statement
    for(int i = 0; i < 5; ++i)
    {
        var button = new Button();
        button.Tag = i;
        button.Click += (sender, e) =>
        {
            var text = new Foo((int)((sender as Button).Tag));
        }
    }
