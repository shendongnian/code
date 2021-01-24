    private MyClass _myClassObject; // class level object. Remember "object" is reserved keyword that is why renamed it to "_myClassObject"
    public void Button1_Click(object sender, EventArgs e)
    {
            // Prefilled with a persons info
            _myClassObject = new MyClass();
    }
    
    public void Button2_Click(object sender, EventArgs e)
    {
        // Access object
        string name = _myClassObject.Name;
    }
