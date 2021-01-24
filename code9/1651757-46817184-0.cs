    private void GetAllData()
    {
        AdminPanelDataAccessLayer apdal = new AdminPanelDataAccessLayer();
        List<PersonalInformation> pi = apdal.GetAllPersonalInfo();
     
        GridView2.DataSource = pi ;
        GridView2.DataBind();
    }
