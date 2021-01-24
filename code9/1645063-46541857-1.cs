        string[] oras = { "07:00AM", "07:30AM", "08:00AM", "08:30AM", "09:00AM", "10:00AM", " 10:30AM", "11:00AM", "11:30AM", "12:00PM", "12:30PM", "01:00PM", "01:30PM", "02:00PM", "02:30PM", "03:00PM", "03:30PM", "04:00PM", "04:30PM", "05:00PM", "05:30PM", "06:00PM", "06:30PM", "07:00PM", "07:30PM", "08:00PM" };
        int elementsCount = oras.Select(DateTime.Parse)
                        .Count(c => c >= DateTime.Parse("07:00AM")
                                 && c <= DateTime.Parse("10:30AM"));
        int startIndex = Array.IndexOf(oras, "07:00AM");
        List<string> orasList = oras.ToList();
        orasList.RemoveRange(startIndex, elementsCount);
        oras = orasList.ToArray();
