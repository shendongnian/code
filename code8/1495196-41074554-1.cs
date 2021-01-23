    var outputString = string.Join(" ", GetSongDescriptions(songs, artists));
    private IEnumerable GetSongDescriptions(string[] songs, string[] artists)
    {
        for (i = 0; i < songs.length; i++)
        {
            yield return string.Format("Song Info: {0}, {1}", songs[i], artists[i]);
        }
    }
