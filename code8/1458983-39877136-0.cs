        protected void Button1_Click(object sender, EventArgs e)
        {
            //first find the ContentPlaceHolder control
            ContentPlaceHolder contentPlaceHolder = FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            
            //then find the GridView control inside the ContentPlaceHolder
            GridView gridview = contentPlaceHolder.FindControl("GridView1") as GridView;
            //or the same as above but in a single line of code
            GridView gridview = FindControl("ContentPlaceHolder1").FindControl("GridView1") as GridView;
            //do stuff with the GridView
            gridview.Visible = false;
        }
