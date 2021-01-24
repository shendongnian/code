    var episode = EpisodeList.FirstOrDefault(x => DoctorList.Any(y => y.Debut == x.Story));
    if (episode != null)
    {
       Debug.WriteLine($"year = {episode.Year}, Title = {episode.Title}");
    }
    
