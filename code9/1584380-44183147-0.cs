    Stopwatch sekunde = new Stopwatch();
    long glavnetocke = 0;
    double cas;
    double tocke = 0;
    sekunde.Start();
    sekunde.Stop();
    cas = sekunde.Elapsed.TotalSeconds;
    tocke = tocke + ((cas / 10));
    if (tocke > 200)
    {
        glavnetocke = glavnetocke + 1;
        tocke = 0;
    }
