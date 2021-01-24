    var sum = Helper.arrayCSV.GroupBy(g => g.FirstLastName).Select(gs => new
    {
        FirstLastName = gs.Key,
        TotalMarks = gs.Sum(g => g.MarksValue)
    }).ToList();
    
    foreach (var s in sum)
    {
        if (s.TotalMarks < 59)
        {
            MessageBox.Show(s.FirstLastName + ": Failed");
        }
        else if (s.TotalMarks >= 60 && s.TotalMarks <= 78)
        {
            MessageBox.Show(s.FirstLastName + ": Credit");
        }
        else if (s.TotalMarks >= 79 && s.TotalMarks <= 89)
        {
            MessageBox.Show(s.FirstLastName + ":  Distinction");
        }
        else if (s.TotalMarks >= 90 && s.TotalMarks <= 100)
        {
            MessageBox.Show(s.FirstLastName + ": Honours");
        }
    }
