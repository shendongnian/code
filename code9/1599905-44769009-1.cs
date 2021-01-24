    public bool OnQueryTextChange(string newText)
        {
           newText = newText.ToLowerCase();
           JavaList<Country> countriesList = new JavaList<>();
           foreach(Country country : countries) // data which you used for populating adapter
            {
               String name = country.getName.ToLowerCase(); // I don't know how your Country class code is setup I suppose you have getters and setters like name for countries
            if(name.Contains(newText))
                countriesList.add(country );
            }
        countyadapter.Filter(countriesList);
        return true;
        }
