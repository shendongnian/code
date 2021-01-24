    private string _content;
    private string content
    {
        set
        {
            if (value != _content)
            {
                _content = value;
                checkContent();
            }
        }
        get
        {
            return _content;
        }
    }
  
 
    private void checkContent()
    {
        if (content.Equals("one"))
        {
            outbox.AppendText("Sunflowers");
        }
        else if (content.Equals("two"))
        {
            outbox.AppendText("Tulips");
        }
        else if (content.Equals("three"))
        {
            outbox.AppendText("Daisies");
        }
        else if (content.Equals("four"))
        {
            outbox.AppendText("Poppies");
        }
        else if (content.Equals("quit"))
        {
            Application.Exit();
        }
        else
        {
            outbox.AppendText("Try again.");
            start();
        }
    }
        private void start()
        {
            outbox.AppendText("Enter one, two, three or four.");
        }
        private void inbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                content = inbox.Text; //inbox is the textbox for input;
            }
            else
            {
                //do nothing
            }
        }
    }
