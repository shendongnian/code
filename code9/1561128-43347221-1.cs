    using (var en1 = sponsorshipQuery1.GetEnumerator())
    {
      foreach(var item2 in sponsorshipQuery2)
      {
        if (!en1.MoveNext())
        {
          break;
        }
        var item1 = en.Current;
        // Do something with the two items here. E.g.
      }
    }
