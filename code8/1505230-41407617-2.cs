    void Method(){
    Task T = Task.Factory.StartNew(() =>
    {
        for (int i=0;i<count;i++)
        {
            UpdateUi functionToUpdateUi = UpdateTextBoxControl;
            if (textBox1.InvokeRequired)
                textBox1.BeginInvoke(functionToUpdateUi);
    
            //textBox1.Text += "x"; this is non-GUI thread. You can't update GUI controls like this
            Thread.Sleep(500);
        }
    });
    T.Wait();
    }
    //declaration of delegate signature
    delegate void UpdateUi();    
    //this is a new method which you will create separately
    private void UpdateTextBoxControl()
    {
        //this method gets executed on GUI thread so it safe
        textBox1.Text = "Changed the text from background thread.";
    }
