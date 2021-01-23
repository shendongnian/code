    int i = 0;
    void Body_KeyDown(object sender, HtmlElementEventArgs e)
    {
        if (e.KeyPressedCode == (int)Keys.Tab && !e.CtrlKeyPressed)
        {
            if (i == 1)
            {
                e.ReturnValue = false;
                SendKeys.Send("^({TAB})");
                this.Text += "[C+T]";       /*Just to be obvious in title-bar for test*/
            }
            else
            {
                this.Text += "[T]";         /*Just to be obvious in title-bar for test*/
            }
            i++;
        }
    }
