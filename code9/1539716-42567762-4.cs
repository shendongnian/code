    protected void Page_Load(object sender, EventArgs e)
    {
        //set the initial number of buttons
        int buttonCount = 1;
        //check if the viewstate with the buttoncount already exists (= postback)
        if (ViewState["buttonCount"] != null)
        {
            //convert the viewstate back to an integer
            buttonCount = Convert.ToInt32(ViewState["buttonCount"]);
        }
        else
        {
            ViewState["buttonCount"] = buttonCount;
        }
        //create the required number of buttons
        for (int i = 1; i <= buttonCount; i++)
        {
            createButton(i);
        }
    }
    private void createButton(int cnt)
    {
        //create a new button control
        Button button = new Button();
        button.Text = "Add another Button (" + cnt + ")";
        //add the correct method to the button
        button.Click += DynamicButton_Click;
        //another control, in this case a literal
        Literal literal = new Literal();
        literal.Text = "<br>";
        //add the button and literal to the placeholder
        PlaceHolder1.Controls.Add(button);
        PlaceHolder1.Controls.Add(literal);
    }
    protected void DynamicButton_Click(object sender, EventArgs e)
    {
        //get the current number of buttons
        int buttonCount = Convert.ToInt32(ViewState["buttonCount"]) + 1;
        //create another button
        createButton(buttonCount);
        //set the new button count into the viewstate
        ViewState["buttonCount"] = buttonCount;
    }
