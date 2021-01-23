    private string _last;
    private string GetNonRepeatedMovie()
    {
        string selected = "";
        do
        {
            selected = movie[r.Next(0, movie.Length)].ToUpper();
        }
        while (selected == this._last);
    
        this._last = selected;
        return selected;    
    }
