     protected void Page_Load(object sender, System.EventArgs e)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                }
            }
            public void Page_Error(object sender, EventArgs e)
            {
                Response.Write("This page is not valid.");
            }
