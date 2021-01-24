    static void Main(string[] args)
    {
        ActivityDBCollection DBData = new ActivityDBCollection();
        DBData.MinedEmailData = new List<Act_Email>();
        Act_Email minedEmailData = Helpers.DataParsers.Extract_Act_Email(emailDataModel);
        DBData.MinedEmailData.Add(minedEmailData);
    }
