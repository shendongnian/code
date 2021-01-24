    public ActionResult NewCountry(string button,string Country,string Notes)
        {
            switch (button)
            {
                case "Save":
                    bool exists = InsertCountry(Country, Notes);
                    if (exists)
                    {
                        return Redirect("/Maintenance/Maintenance/Country?alert=true");
                    }
                    else
                        return Redirect("/Maintenance/Maintenance/Country");
                case "Cancel":
                    //Need to redirect to the countries page. 
                    return Redirect("/Maintenance/Maintenance/Country");
            }
            return View();
        }
