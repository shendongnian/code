    // This is assuming you're absolutely sure of the format used. This is *not*
    // necessarily the user's preferred format. You should think about where your
    // data is coming from.
    DateTime date;
    if (DateTime.TryParseExact(text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out date))
    {
        // Okay, successful parse. We now have the date. Use it, avoiding formatting
        // it back to a string for as long as possible.
    }
