    public partial class Form1 : Form
    {
        public Panels Panels=new Panels();
        public Form1()
        {
                InitializeComponent();
                Panels.PanelsArray[0,0]=p00;
                PanelsPanelsArray[1,0]=p10;
                Panels.PanelsArray[2,0]=p20;
                //...
                Panels.PanelsArray[5,5]=p55;
                
        }
    ...
