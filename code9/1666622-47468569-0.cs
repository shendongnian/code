    public string[] myDate(string date, string year)
        {
            string date1 = date.Split('-')[0];
            string date2 = date.Split('-')[1];
            string[] dateSplit1 = date1.Split();
            string[] dateSplit2 = date2.Split();
            return new string[] { dateSplit1[1] + "-" + dateSplit1[0].ToUpper() + "-" + year, dateSplit2[2] + "-" + dateSplit2[1].ToUpper() + "-" + year };
        }
