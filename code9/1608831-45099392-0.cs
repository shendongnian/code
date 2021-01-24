    Form1 form1Ref;
    
    public Form2(Form1 mainform)
    {
         form1Ref = mainform;
    }
    
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
         form1Ref.SomeMethod();
    }
