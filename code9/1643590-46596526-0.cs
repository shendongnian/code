    public partial class Form1 : Form
    {
     public Form1()
     {
        InitializeComponent();
 
        this.radDateTimePicker1.SizeChanged += RadDateTimePicker1_SizeChanged;
    }
 
     private void RadDateTimePicker1_SizeChanged(object sender, EventArgs e)
     {
        int width = this.radDateTimePicker1.Width;
        int height = 300;//calculate it according to your formula
        Size desiredSize = new Size(width, height);
 
        RadDateTimePickerCalendar cal = this.radDateTimePicker1.DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar;
        // Control popup size
        cal.DropDownMinSize = desiredSize;
        cal.DropDownMaxSize = desiredSize;
    }
}
