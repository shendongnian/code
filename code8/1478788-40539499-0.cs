    interface IHasDiciplines
    {
        string Disciplines { get; set; }
        List<Disciplines> DisciplinesCBG { get; set; }
    }
    class UserProfileViewModel : IHasDiciplines
    {
        public string Disciplines { get; set; }
        public List<Disciplines> DisciplinesCBG { get; set; }
    }
    public static IHasDiciplines DisciplinesStringToCheckboxGroup(IHasDiciplines  model)
    {
        string[] disciplineArray = model.Disciplines.Split(',');
        for (int i = 0; i < model.DisciplinesCBG.Count; i++)
        {
            string currentValue = model.DisciplinesCBG[i].Discipline;
            if(Array.IndexOf(disciplineArray, currentValue) > -1)
            {
                model.DisciplinesCBG[i].IsChecked = true;
            }
        }
        return model;
    }
