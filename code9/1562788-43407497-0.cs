    if (<filter is Atlas>)
    {
      query = query.Where(d => ((d as DetectorStatu).Detector as Detector).EnabledDetectorTypes.Count(t => t.DetectorTypeID == 1) > 0);
    }
    else if (<filter is Phoenix>)
    {
      query = query.Where(d => ((d as DetectorStatu).Detector as Detector).EnabledDetectorTypes.Count(t => t.DetectorTypeID == 2 || t.DetectorTypeID == 3) > 0);
    }
