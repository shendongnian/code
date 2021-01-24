    protected void SearchBtn_Click(object sender, EventArgs e){
        if (!IsPostBack){
            Search_Grid(SearchData.Text);
        }
    }
    
    void Search_Grid(string searchValue){ 
        DataGridView.DataSource = obj.Search_Data(searchValue);
        DataGridView.DataBind();
    }
