    public class EventForm : Form
    {
        public EventForm()
        {
            this.Load += AddControls;
        }
        private void AddControls (object sender, EventArgs e)
        {
            DateTimePicker startDate = new DateTimePicker();
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.CustomFormat = "MMM dd, yyyy — h:mm tt";
            startDate.Dock = DockStyle.Top;
            this.Controls.Add(startDate);
            // Add the rest of your controls here.
        }
    }
