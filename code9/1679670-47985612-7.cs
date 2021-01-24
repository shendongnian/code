    var es = EpisodeList.Where(x => DoctorList.Any(y => y.Debut == x.Story));
    foreach (var e in es)
    {
        Companions.Items.Add(String.Format(e.Title + " (" + e.Year + ")"));
        Companions.Items.Add("");
    }
    
