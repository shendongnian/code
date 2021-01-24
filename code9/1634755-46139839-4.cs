    public partial class Form1 : Form
    {
        public Panels Panels;
        public Form1()
        {
                InitializeComponent();
                Panels=new Panels()
                {
                    PanelsArray[0,0]=p00,
                    PanalsArray[1,0]=p10,
                    PanalsArray[2,0]=p20,
                ...
                    PanalsArray[5,5]=p55
                };
        }
    ...
