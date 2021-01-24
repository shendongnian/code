    List<Episode> es = EpisodeList.Where(x => DoctorList.Any(y => y.Debut == x.Story)).ToList();
    foreach (Episode e in es)
    {
        Companions.Items.Add(String.Format(e.Title + " (" + e.Year + ")"));
        Companions.Items.Add("");
    }
