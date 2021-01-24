    [WebMethod]
            public static string GetCityDetails(string cityName)
            {
                MessageBox.Show(cityName);
                return "success";
            }
