     public class ViewModel
        {
            public List<Label> MyLabels { get; set; }
    
            public ViewModel()
            {
                if (MyLabels == null) MyLabels = new List<Label>();
                for (int i = 0; i < 5; i++)
                {
                    Label sample = new Label();
                    sample.Content = "Sample";
                    MyLabels.Add(sample);
                }
            }
    
        }
