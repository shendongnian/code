    public string GetImageUrl(bool inhouse, DateTime expectedArrival)
    {
        const string checkedIn = "/Images/Icons/Visitor-checkedin-16x16.png";
        const string checkedOut = "/Images/Icons/Visitor-checkedout-16x16.png";
        const string notArrived = "/Images/Icons/Visitor-notarrived-16x16.png";
        string imageUrl = null; //separate variable to hold the chosen image URL
        if (inhouse == true)
        {
            imageUrl = checkedIn;
        }
        else if (inhouse == false && expectedArrival.AddDays(0) <= DateTime.Now)
        {
            imageUrl = notArrived;
        }
        else
        {
            imageUrl = checkedOut;
        }
        return imageUrl;
    }
