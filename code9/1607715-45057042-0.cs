    namespace MyProject
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                 Methods.Init(this);
            }
        }
    
    
        class  Methods 
        {
            //need to create method to Form 1 From herer
            public static void Init(Form frm)
            {
                frm.Controls.Add((new CreateControl()).CreateButton("Test"));
            }
        }
    
        class EventHandlerWrapper
        {
            //need to create EventHandler to Form 1 From herer
            private void button_Click(object sender, EventArgs e)
            {
                MessageBox.Show("TEST");
            }
        }
    
        class CreateControl
        {
            public Button CreateButton(string text)
            {
                 EventHandlerWrapper e = new EventHandlerWrapper();
                 Button btn = new Button();
                 btn.Text = text;
                 btn.Click += e.button_Click;
            }
        }    
    }
