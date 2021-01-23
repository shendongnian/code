    internal SessionsManager()
    {
        Sessions = new SessionData[5] {
            new Data("1", "Title1", "speaker1", "desc1", DateTime.Today, true),
            new Data("2", "Title2", "speaker2", "desc2", DateTime.Today, false),
            new Data("3", "Title3", "speaker3", "desc3", DateTime.Today, false),
            new Data("4", "Title4", "speaker4", "desc4", DateTime.Today, true),
            new Data("5", "Title5", "speaker5", "desc5", DateTime.Today, true)
        };
    }
