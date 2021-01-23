    var outputString = string.Join(" ", GetSongDescriptions(songs, artists));
    private IEnumerable GetSongDescriptions(string[] songs, string[] artists)
    {
        for (i = 1, i < songs.length, i++)
        {
            yield return string.Format("Song Info: {songs[i]}, {artists[i]}");
        }
    }
