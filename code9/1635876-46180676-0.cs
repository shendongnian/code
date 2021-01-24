    protected void DisplayOPD(List<string> lst)
            {
                try
                {
                    if (lst != null)
                    {
                        GridView1.DataSource = (from arr in lst select new { ID = arr[0], Name = arr[1], Age = arr[2], Gender = arr[3], Contact = arr[4], Address = arr[5], User = arr[6], Type = arr[7] });
                        GridView1.DataBind();
                        div_grid.Visible = true;
                    }
                }
                catch (Exception ex)
                {
    
                    throw;
                }
            }
