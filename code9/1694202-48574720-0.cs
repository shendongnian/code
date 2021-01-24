    string Furnished = string.Empty;
            string Parking = string.Empty;
            string Garden = string.Empty;
            string Terrace = string.Empty;
            string Wifi = string.Empty;
            string Heating = string.Empty;
    
            List<ListItem> selectedItem = chkAmenities.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            foreach (ListItem item in selectedItem)
            {
                switch (item.Text)
                {
                    case "Furnished": Furnished = "Furnished"; break;
                    case "Parking": Parking = "Parking"; break;
                    case "Garden": Garden = "Garden"; break;
                    case "Terrace/Balcony": Terrace = "Terrace/Balcony"; break;
                    case "Wifi": Wifi = "Wifi"; break;
                    case "Heating": Heating = "Heating"; break;
                }
            }
