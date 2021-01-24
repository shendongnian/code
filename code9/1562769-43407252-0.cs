    public partial class Game : Form
    {
        List<Animal> animalList = new List<Animal>();
        Dictionary<Animal, Panel> animalPanels = new Dictionary<Animal, Panel>();
        ...
                // For each animal.
                a.Spawn();
                GameGrid.Controls.Add(birdPanel, a.XCoordinate, a.YCoordinate);
                animalPanels.Add(a, birdPanel);
        ...
        private void NextMoveButton_Click(object sender, EventArgs e)
        {
            // Access GameGrid.Controls.
            // Or animalPanels.
        }
    }
