    public void ShowForm()
    {
        this.Show();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Hello();     //Display your MessageBox based on the button click
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }
    public void Hello()
    {
        MessageBos.Show("Hello");
    }
    Dim test
    Set test = CreateObject("Playground_DLL.Form1")     //This is where you initialize
    test.topMost = true
    //test.Hello()                                      //This is to display the message box - not Form1
    test.ShowForm();                                    //This displays Form1
    
