            DateTime startDate = DateTime.Now.AddDays(-5); //5 days ago.
            DateTime endDate = DateTime.Now;
            List<string> Dates = new List<string>();
            for (int i = 0; i <= endDate.Subtract(startDate).Days; i++)
            {
                Dates.Add(startDate.AddDays(i).ToString()); //sample!
                //if enddatedata is the date that must icrease and startDate is the first Date:
                enddatedata = startDate.AddDays(i);
                // SQL insert HERE
            }
            //Dates:
            //2017-02-26 5:45:25 PM
            //2017-02-27 5:45:25 PM
            //2017-02-28 5:45:25 PM
            //2017-03-01 5:45:25 PM
            //2017-03-02 5:45:25 PM
            //2017-03-03 5:45:25 PM
