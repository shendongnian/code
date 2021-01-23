    public string GetImageUrl(string inhouse, DateTime expectedArrival)
        {
            const string checkedIn = "/Images/Icons/Visitor-checkedin-16x16.png";
            const string checkedOut = "/Images/Icons/Visitor-checkedout-16x16.png";
            const string notArrived = "/Images/Icons/Visitor-notarrived-16x16.png";
            bool result;
            bool.TryParse(inhouse, out result);
            if (result)
            {
                inhouse = checkedIn;
            }
            else if (expectedArrival.AddDays(0) <= DateTime.Now)
            {
                inhouse = notArrived;
            }
            else
            {
                inhouse = checkedOut;
            }
            return inhouse;
        }
