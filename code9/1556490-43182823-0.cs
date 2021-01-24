    public class Step
    {
        public string Name { get; set; }
        public Image StatusImage { get; set; }
    }
    // Create collection
    var steps = new List<Step>
    {
        new Step { Name = "One", StatusImage = image1 },
        new Step { Name = "Two", StatusImage = image1 },
        new Step { Name = "Three", StatusImage = image1 }
    }
    yourDataGridView.DataSource = steps;
