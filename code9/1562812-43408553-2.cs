    public MainWindow()
    {
      InitializeComponent();
      List<Agent> agents = new List<Agent>
      {
        new Agent
        {
          Category = "Category"
        }
      };
      DataContext = agents;
    }
    public class Agent
    {
      public string Category
      {
        get;
        set;
      }
    }
