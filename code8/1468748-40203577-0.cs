    var ids = new List<int> { -1342177274, -1073741819, -805306364, -805306364 };
        var tc= db.Territories.where(x=>ids.Contains(x.Terr_TerritoryID))
                .select new
                {
                terCapt = t.Terr_Caption,
                terID = t.Terr_TerritoryID
                };
                .ToList();
