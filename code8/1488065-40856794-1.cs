    private void button4_Click(object sender, EventArgs e)
    {
        MyArray<int> myInt = new MyArray<int>(5); //Initializing the generic class.
        myInt.SetItem(0, 1); //array element 0 is going to be assigned a value of 1.
        MessageBox.Show(myInt.GetItem(0).ToString());
        //You can also use the same class, to set string values.
    }
