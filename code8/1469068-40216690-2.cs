    protected void Button1_Click(object sender, EventArgs e)
    {
       Person p = new Person(TextBox1.Text, DropDownList1.SelectedValue, Calendar1.SelectedDate);
        Label1.Text = p.PrintPerson();
        Test = (List<Person>)Session["carrytonext"];
        Test.Add(new Person(TextBox1.Text, DropDownList1.SelectedValue, Calendar1.SelectedDate));
        // Add this line to your code
        Session["carrytonext"] = Test;       
    }
