    // you should be able to use a list...
    List<Vehicle> list = new List<Vehicle>();
    
    // or if you must use an array
    Vehicle[] array; // initialize it like you do in your example
    int arrayPosition = 0;
    
    private void button1_Click(object sender, EventArgs e)
    {
        // create an instance of a strongly typed object using your textboxes, etc.
        Vehicle v = new Vehicle();
        v.Make = textBoxMake.Text;
        v.PurchaseDate = dtpickerPurchaseDate.Value;
        v.Engine = comboBoxEngine.SelectedText;
    
        // add the strongly typed object to a list
        list.Add(v);
    
        // or if you must use an array
        array[arrayPosition] = v;
        arrayPosition++;
    
        // you can call a method that expects an array even if you are using a list
        DoStuffWithTheArray(list.ToArray());
    
        // or if you must use an array
        DoStuffWithTheArray(array);
    }
    
    private void DoStuffWithTheArray(Vehicle[] array)
    {
        // expects an array of vehicles, but you can call it with a list or an array.
    }
