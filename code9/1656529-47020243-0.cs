    public partial class Form1 : Form
    {
    public Form1()
    {
        InitializeComponent();
        CreateParty createparty = new CreateParty(this);
        generateIcons();
    }
    public class CreateParty
    {
    public Form1 mainForm;  //This line was updated
    public CreateParty(Form1 form1)
    {
        mainForm = form1;
        testVoid();
    }
    public void testVoid()
    {
        Button NAButton = new Button();
        NAButton.Height = 100;
        NAButton.Width = 100;
        NAButton.Location = new Point(190, 100);
        NAButton.Text = "NA";
        mainForm.gameScrollBar.Controls.Add(NAButton);
    }
