    int result = 0;
    try
    {
        EventType produ = new EventType(int.Parse(tb_id.Text), tb_Name.Text);       
        result = produ.EventTypeInsert();
        if (result > 0)
        {
            Response.Write("<script>alert('Insert successful');</script>");
        }
        else
        {
            Response.Write("<script>alert('Insert NOT successful');</script>");
        }
    }
    catch (SqlException ex)
    {
         Response.Write("<script>alert('ID probably already exists.Insert NOT successful');</script>");
    }
    catch (Exception ex)
    {
         // maybe log a general error
    }
