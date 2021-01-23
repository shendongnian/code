            if (!IsPostBack)
        {
            try
            {
                DLSearchResultsReps.DataSource = GlobalFunctions.GetRepsum(Session["branchid"].ToString(), 100, status.ToString(), producer);
                DLSearchResultsReps.DataBind();
                if (DLSearchResultsReps.Items.Count > 0) // Any Results?
                {
                    SearchResultsRepsPanel.Visible = true;
                }
            }
            catch
            {
                Response.Redirect("error.aspx?msg=ERROR!");
            }
        }
    }
