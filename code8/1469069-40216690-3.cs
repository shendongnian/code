    protected void Page_Load(object sender, EventArgs e)
    {
        List<Person> test = (List<Person>)Session["carrytonext"];  
        foreach (var inputstring in Test)
        {
            // change here
            ListBox1.Items.Add(inputstring.PrintPerson()+" ");
        }
    }
