    public partial class MainForm : Form
    {
        MyControl myControl;
        void Subscribe()
        {
            myControl.ButtonClicked += myControl_ButtonClicked;
        }
        void myControl_ButtonClicked(Button button)
        {
            // Change panel content
            // Resize window
        }
    }
