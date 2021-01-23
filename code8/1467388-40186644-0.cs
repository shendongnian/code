    public ActionResult Search(string search_string) {
        var srchTerms = search_string.Split(new[] { ' ' });
        return view(db.AttributesTable.Where(
           x => srchTerms.Any(s => x.Description.Contains(s)).ToList());
    }
