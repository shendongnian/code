    public partial class MyFormWithButtons : Form
    {
      public MyFormWithButtons(UserControl control)
      {
        InitializeComponent();
        control.Dock = DockStyle.Fill;
        myPanel.Controls.Add(control);
      }
    }
