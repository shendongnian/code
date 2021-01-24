    public string RemoveCountryCode()
        {
            string phonenumber = "+91123123123";
            List<string> countries_list = new List<string>();
            countries_list.Add("+1");
            countries_list.Add("+91");
            foreach(var country in countries_list)
            {
                 phonenumber = phonenumber.Replace(country, "");
                
            }
            return phonenumber;
        }
