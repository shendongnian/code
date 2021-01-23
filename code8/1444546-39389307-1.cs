    public static void Locate(List<LocationInformation> myInformations, int id)
    {
        DateTime lastCheck = DateTime.MinValue;
        foreach (LocationInformation locationInformation in myInformations.Where(i => i.ID == id).OrderBy(i => i.Date))
        {
            // Less than 5 min check
            if (locationInformation.Date < lastCheck.AddMinutes(5))
            {
                continue;
            }
            lastCheck = locationInformation.Date;
            Console.Out.WriteLine(locationInformation);
        }
    }
