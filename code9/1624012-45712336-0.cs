    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 0)
            {
                // If it is not post back and no querystring parameters,
                // load default properties.
                GetDefault();
            }
            else
            {
                // If there are any querystring parameters,
                // Use them to filer the result and set the control values.
                if (Request.QueryString["city"] != null)
                {
                    string aCityName = Request.QueryString["city"].ToString();
                    cityID = service.getCityByName(aCityName);
                    search_by_city.Value = cityID.ToString();
                }
                else
                {
                    cityID = 0;
                }
                //To get state
                if (Request.QueryString["state"] != null)
                {
                    string aState = Request.QueryString["state"].ToString();
                    state = service.getStateByName(aState);
                    search_by_state.Value = state.ToString();
                }
                else
                {
                    state = 0;
                }
    
                //To get country
                if (Request.QueryString["country"] != null)
                {
                    string aCountry = Request.QueryString["country"].ToString();
                    country = DLResale.getConfigByName(aCountry);
                    search_by_country.Value = country.ToString();
                }
                else
                {
                    country = 0;
                }
                GetProperties(city, state, city)
            }
        }
    }
 
