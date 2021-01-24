    int systemID = 210;
    var cross = TreatmentSites.Select(ts => new {
      TreatmentSiteID = ts.ID,
      TreatmentSiteName = ts.Description,
      Checked = string
        .Join("", TreatmentCheckTypes
                  .OrderBy(tct => tct.ID)
                  .Select(cs => SystemTreatmentSitesCheckeds
                    .Any(s => s.Active
                           && s.SystemID == systemID
                           && s.TreatmentSiteID == ts.ID
                           && s.TreatmentCheckTypeID == cs.ID) ? "y" : "n"))
    })
    .ToArray();
