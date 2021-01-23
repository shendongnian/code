    //string
    Session["LoggedInOk"] = "loginOk";
    string value = Session["LoggedInOk"].ToString();
    
    //bool
    Session["LoggedInOk"] = true;
    bool value = Session["LoggedInOk"] as bool;
    
    //class
    Book book = new Book();
    Session["LoggedInOk"] = book;
    Book value = Session["LoggedInOk"] as Book;
    //datatable
    DataTable table = new DataTable();
    Session["LoggedInOk"] = table;
    DataTable value = Session["LoggedInOk"] as DataTable;
