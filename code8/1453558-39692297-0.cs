    private class RunnersAndTimes
    {
        public string Name {get};
        public double Time {get};
        public RunnersAndTimes(string name, double time)
        {
            Time = time;
            Name = name;
        }
    }
    ...
    private void calculateButton_Click(object sender, EventArgs e)
    {
        var runnersAndTimes = new List<RunnersAndTimes> {
            new RunnersAndTimes(runnerOneNameTextBox.Text, 
                                double.Parse(runnerOneTimeTextBox.Text)),
            new RunnersAndTimes(runnerTwoNameTextBox.Text, 
                                double.Parse(runnerTwoTimeTextBox.Text)),
            new RunnersAndTimes(runnerThreeNameTextBox.Text, 
                                double.Parse(runnerThreeTimeTextBox.Text))
        };
        var orderedRunners = runnersAndTimes.OrderBy(runner => runner.Time).ToList();
        firstPlaceLabel.Text = orderedRunners[0];
        secondPlaceLabel.Text = orderedRunners[1];
        thirdPlaceLabel.Text = orderedRunners[2];
    }
