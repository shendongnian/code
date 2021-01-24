    if (checkEnd && dateFound != null)
    {
        if (dateFound >= date && dateFound <= dateEnd)
        {
            Console.WriteLine("Date found between"); //foundPictures.Add(pic);
        }
        else if (dateFound != null)
        {
            Console.WriteLine("single date found");//foundPictures.Add(pic);
        }
        else
        {
            Console.WriteLine("No dates found");
        }
    }
