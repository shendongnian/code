    protected void GuitarBrandsGridViewBtn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow gridrow = btn.NamingContainer as GridViewRow;
        
        Label lblName = gridrow.FindControl("lblName");
        string name = lblName.Text;
    }
