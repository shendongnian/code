    [HttpPost]
    public void YourAction(string yourText)
    {
          if (String.IsNullOrWhiteSpace(yourText))
        {
            return View(db.Regions.ToList());
        }
        else
        {
            List<Regions> collectionOfRegions = db.Regions.ToList();
            return View(collectionOfRegions.Where(x => x.MatchBetweenAllFields(yourText)));
        }
    }
