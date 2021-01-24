     using System.Linq;
     ...
     public Form1() {
       InitializeComponent();
 
       // If you want all the panels, remove "Where"
       Panel[] arr = Controls
        .OfType<Panel>()
        .Where(panel => Regex.IsMatch(panel.Name, "^panel([0-9]|(10))$"))
        .ToArray();
    }
