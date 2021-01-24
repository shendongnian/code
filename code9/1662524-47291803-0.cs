    List<Book> books;
    int pageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        //fill the collection
        books = fillBooks();
        //create the dynamic pager buttons, this needs to be done on every page load
        createPager();
        //bind the grid for the first time without postback
        if (!IsPostBack)
        {
            bindGrid(0);
        }
    }
    private void bindGrid(int offSet)
    {
        //bind the right amount of items to the grid
        GridView1.DataSource = books.Skip(offSet).Take(pageSize).ToList();
        GridView1.DataBind();
    }
    private void createPager()
    {
        //loop for every x items in the collection
        for (int i = 0; i < (books.Count / pageSize); i++)
        {
            //create a linkbutton
            LinkButton lb = new LinkButton();
            //add the properties
            lb.Text = (i + 1).ToString();
            lb.CommandArgument = i.ToString();
            //bind the command method
            lb.Command += Lb_Command;
            //add the linkbutton to the page
            PlaceHolder1.Controls.Add(lb);
            //add some spacing
            PlaceHolder1.Controls.Add(new Literal() { Text = "&nbsp;" });
        }
    }
    private void Lb_Command(object sender, CommandEventArgs e)
    {
        //rebind the grid with the next 10 items
        bindGrid(Convert.ToInt32(e.CommandArgument) * 10);
    }
