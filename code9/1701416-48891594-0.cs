    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //bind the datasource for the listview
            Lv_question.DataSource = source;
            Lv_question.DataBind();
        }
    }
    protected void Lv_question_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        //use findcontrol to locate the radiobuttonlist and cast is back
        RadioButtonList rbl = e.Item.FindControl("Rbl_options") as RadioButtonList;
        //add some dummy listitems
        for (int i = 0; i < 3; i++)
        {
            rbl.Items.Add(new ListItem() { Text = "Item " + i, Value = i.ToString() });
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //loop all the items in the listview
        foreach (var item in Lv_question.Items)
        {
            //use findcontrol again to locate the radiobuttonlist in the listview item
            RadioButtonList rbl = item.FindControl("Rbl_options") as RadioButtonList;
            //show results
            Label1.Text += rbl.SelectedValue + "<br>";
        }
    }
