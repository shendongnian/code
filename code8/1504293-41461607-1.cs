    protected void Button1_Click(object sender, EventArgs e)
    {
        //Some stuff
        for (int i = 0; i < grid.VisibleRowCount; i++)
        {
            //Other stuff                
            if (grid.Selection.IsRowSelected(i))
            {
                //Do conditional stuff
            }
            //More stuff
        }
        //Even more stuff
    }
