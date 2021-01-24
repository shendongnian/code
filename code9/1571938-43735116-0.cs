    protected void Page_Load(object sender, EventArgs e)
    {
        createDynamicControls();
    }
    public void createDynamicControls()
    {
        //add a textbox
        TextBox tb = new TextBox();
        tb.ID = "DynamicTextBox";
        tb.Text = "TextBox Content";
        PlaceHolder1.Controls.Add(tb);
        //add a dropdownlist
        DropDownList drp = new DropDownList();
        drp.ID = "DynamicDropDownList";
        drp.Items.Insert(0, new ListItem("Value A", "0", true));
        drp.Items.Insert(1, new ListItem("Value B", "1", true));
        PlaceHolder1.Controls.Add(drp);
        //add a button
        Button btn = new Button();
        btn.Text = "Submit Dynamic Form";
        btn.Click += Button1_Click;
        PlaceHolder1.Controls.Add(btn);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //find the dynamic controls again with findcontrol
        TextBox tb = FindControl("DynamicTextBox") as TextBox;
        DropDownList drp = FindControl("DynamicDropDownList") as DropDownList;
        //visualize the values
        Label1.Text = tb.Text + "<br>";
        Label1.Text += drp.SelectedItem.Text;
    }
