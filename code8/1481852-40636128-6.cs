    protected void viewAll_Command(object sender, CommandEventArgs e)
    {
        //check which gridview for setting all the rows visible
        if (e.CommandName == "GridView1")
        {
            //disable pagination and rebuild the grid
            GridView1.AllowPaging = false;
            buildGridView1();
        }
        else if (e.CommandName == "GridView2")
        {
            GridView2.AllowPaging = false;
            buildGridView2();
        }
        else if (e.CommandName == "ListView1")
        {
            DataPager dataPager = ListView1.FindControl("DataPager1") as DataPager;
            dataPager.PageSize = 99999;
            buildListView1();
        }
    }
