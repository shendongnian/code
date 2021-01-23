    List<int> NumberList = new List<int>();
    for (int i = 1; i <= 100; i++)
    {
        NumberList.Add(i);
    }
    SiteSurveyModel.AtsNumberCollection = new ObservableCollectionEx<int>(NumberList);
