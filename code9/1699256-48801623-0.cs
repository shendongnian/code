    Control control = Controls.Find("btnTest", true).FirstOrDefault(); //find control by name
    if(control != null)
    {
      btnTest.Click -= btnTest_Click; //Remove Default Event Handler.
      control.Click += Form1_Click; //generate button click
    }
