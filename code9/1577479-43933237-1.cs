    public IList<Film> SearchFilms(string textSearch)
    {
        IList<Film> list = new List<Film>();
        using (Analyzer analyzer = new PanGuAnalyzer())
        {
            var queryParser = new QueryParser(Version.LUCENE_30, "FullText", analyzer);
            queryParser.AllowLeadingWildcard = true;
            var query = queryParser.Parse(textSearch);
            var collector = TopScoreDocCollector.Create(1000, true);
            Searcher.Search(query, collector);
            var matches = collector.TopDocs().ScoreDocs;
            
            foreach (var item in matches)
            {
                var film = new Film();
                var id = item.Doc;
                var doc = Searcher.Doc(id);
                film.Title = doc.GetField("Title").StringValue;
                film.Starring = doc.GetField("Starring").StringValue;
                film.ID = doc.GetField("ID").StringValue;
                list.Add(film);
            }
        }
        return list;
    }
