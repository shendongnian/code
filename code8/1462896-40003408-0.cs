        try
        {
            LoadData();
            BindGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
