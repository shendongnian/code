     using System.Linq;
     using System.Text.RegularExpressions;
     ...
     public Form1() {
       InitializeComponent();
 
       // If you want all the panels, remove (comment out) "Where"
       Panel[] arr = Controls
        .OfType<Panel>()
        .Where(panel => Regex.IsMatch(panel.Name, "^panel([0-9]|(10))$"))
        .ToArray();
     }
