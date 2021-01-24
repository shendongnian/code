    public class Form1 : Form
    {
        // justCounts is a reference to the object wherever it is coming from
        justCounts.PropertyChanged += new PropertyChangedEventHandler(JustCountsChangedHandler);
        private void JustCountsChangedHandler(object sender, PropertyChangingEventArgs e)
        {
            // process on event firing
            Debug.WriteLine($"justCounts TotalCount changed value to {justCounts.TotalCount}");
        }
        // Example of where the handler will fire when called
        private void button1_click(object sender, EventArgs e)
        {
            justCounts.TotalCount++;
        }
    }
