    public partial class MessageBoxEx : Window
    {
        private string FMessage = string.Empty;
        private string FResult = (string)null;
        private string FBtn0 = (string)null;
        private string FBtn1 = (string)null;
        private string FBtn2 = (string)null;
        private bool _contentLoaded;
        public string Btn0
        {
            get
            {
                return this.FBtn0;
            }
            set
            {
                this.FBtn0 = value;
            }
        }
        public string Btn1
        {
            get
            {
                return this.FBtn1;
            }
            set
            {
                this.FBtn1 = value;
            }
        }
        public string Btn2
        {
            get
            {
                return this.FBtn2;
            }
            set
            {
                this.FBtn2 = value;
            }
        }
        public string Message
        {
            get
            {
                return this.FMessage;
            }
            set
            {
                this.FMessage = value;
            }
        }
        public string Result
        {
            get
            {
                return this.FResult;
            }
        }
        public TextBlock TextBlock
        {
            get
            {
                return this.PartTextBlock;
            }
        }
        public MessageBoxEx()
        {
            this.InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.PartTextBlock.Inlines.Count < 1)
                this.PartTextBlock.Text = this.FMessage;
            this.SetupButton();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        private void SetupButton()
        {
            if (this.FBtn0 != null)
                this.CreateButton("btn1", this.FBtn0);
            if (this.FBtn1 != null)
                this.CreateButton("btn2", this.FBtn1);
            if (this.FBtn2 != null)
                this.CreateButton("btn3", this.FBtn2);
            Border border = new Border();
            border.Width = 10.0;
            this.PartStackPanel.Children.Add((UIElement)border);
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "btn1")
                this.FResult = "0";
            else if (button.Name == "btn2")
                this.FResult = "1";
            else if (button.Name == "btn3")
                this.FResult = "2";
            this.Close();
        }
        private void CreateButton(string name, string caption)
        {
            Button button = new Button();
            button.Name = name;
            button.Width = 80.0;
            button.Content = (object)caption;
            button.Margin = new Thickness(0.0, 15.0, 4.0, 0.0);
            button.Click += new RoutedEventHandler(this.button_Click);
            this.PartStackPanel.Children.Add((UIElement)button);
        }
    }
