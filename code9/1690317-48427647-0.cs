    using System;
    using System.Windows.Forms;
    public partial class Form1 : Form, IMessage
    {
        private MessageController ctrl;
        public Form1()
        {
            InitializeComponent();
            ctrl = new MessageController(this);
        }    
   
        private void Form1_Load(object sender, EventArgs e)
        {
            ctrl.Greeting();
        }
    
        public void Hello()
        {
            MessageBox.Show("Hello World");
        }
    }
    
    class MessageController
    {
        private IMessage messageClient;
    
        public MessageController(IMessageClient client)
        {
            messageClient = client;
        }
        public void Greeting()
        {
            messageClient.Hello();
        }
    }
    interface IMessage
    {
        void Hello();
    }
