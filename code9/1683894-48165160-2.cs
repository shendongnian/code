    public HomePage()
    {
    
        // You need to populate them with a Title and Page Type using typeof()
    
        Pages.Add(new MasterPageItem("My Account", typeof(LoginPage)));
        Pages.Add(new MasterPageItem("Charity At", typeof(CharityAPage)));
        Pages.Add(new MasterPageItem("Charity B", typeof(CharityBPage)));
    
        ...
