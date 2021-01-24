      protected void GuitarBrandsGridView_RowDeleting(object sender,    GridViewDeleteEventArgs e)
    {
    int id = Convert.ToInt32(GuitarBrandsGridView.DataKeys[e.RowIndex].Value.ToString());
    Label name = (Label)GuitarBrandsGridView.Rows[e.RowIndex].FindControl("Label4");
    con1.Open();
    cmd1.CommandText = "DELETE FROM [guitarBrands] WHERE id=" + id;
    cmd1.Connection = con1;
    int a = cmd1.ExecuteNonQuery();
    con1.Close();
    if (a > 0)
    {
        bindgridviewguitarbrands();
    }
    RemoveCodeToGuitarFile.RemoveAddGuitarClass(name.Text);
    RemoveCodeToGuitarFile.RemoveConnectionClassGuitarItems(name.Text);
    RemoveCodeToGuitarFile.RemoveOverviewGuitarDataASPX(name.Text);
    RemoveCodeToGuitarFile.RemoveOverviewGuitarDataCode(name.Text);
    File.Delete(@"C:\Users\User1\Documents\Visual Studio 2015\WebSites\MusicStore\Pages\GuitarItems" + id + ".aspx");
    File.Delete(@"C:\Users\User1\Documents\Visual Studio 2015\WebSites\MusicStore\Pages\GuitarItems" + id + ".aspx.cs");
    ConnectionClassGuitarBrands.RemoveGuitarBrandsDatabase(name.Text);
    Response.Redirect("url"); //The answer to this question
    }
