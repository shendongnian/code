    public class ViewModel
    {
        public List<string> MyLabels { get; set; } new List<string>();
        public ViewModel()
        {
            AddLabels();
        }
        public void AddLabels()
        {
            for (int i = 0; i < 5; i++)
            {
                MyLabels.Add("Sample");
            }
        }
    }
