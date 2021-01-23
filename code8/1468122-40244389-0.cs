    // These come in as "YYYYMM" values (such as "201509"); need them to be 9/1/2016 and suchlike
    private string ConvertToMMDDYYYY(string monthYear)
    {
        string YYYY = monthYear.Substring(0, 4);
        string MM = monthYear.Substring(4, 2);
        return string.Format("{0}/1/{1}", MM, YYYY);
    }
