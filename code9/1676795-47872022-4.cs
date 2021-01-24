    public partial class EngineForm : Form
    {    
        public EngineForm()
        {
            InitializeComponent();
        }
    }
    public class Engine
    {
        public Engine(EngineForm form, Erp erp)
        {
            this.form = form;
            this.erp = erp;
        }
        
        // Here is where you'll write some code to coordinate
        // communication between the Erp and the EngineForm. 
        //
        // The main advantage is that you can inject the Erp 
        // and have it preconfigured.
    }
