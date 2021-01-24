    private MyClass myClassObject; // class level object "object" is reserved keyword that is why changed it to "myClassObject"
    public void Button1_Click(object sender, EventArgs e)
    {
            // Prefilled with a persons info
            myClassObject = new MyClass();
    }
    
    public void Button2_Click(object sender, EventArgs e)
    {
        // Access object
        string name = myClassObject.Name;
    }
