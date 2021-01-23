        private Dictionary<Button, Label> correspondingControls;
        private Dictionary<Button, string> initialButtonInscriptions;
        private List<string> sayingsList;
        private Button currentButton;
        private int ii;
        public Form1()
        {
            InitializeComponent();
            this.SerCorrespondingButtons();
            this.SetCorrespondingInitialButtonInscriptions();
        }
        private void SerCorrespondingButtons()
        {
            correspondingControls = new Dictionary<Button, Label>()
                                                                      {
                {this.buttonOne, this.sayingOne},
                {this.buttonTwo, this.sayingTwo},
                                                                      };
        }
        private void SetCorrespondingInitialButtonInscriptions()
        {
            this.initialButtonInscriptions = new Dictionary<Button, string>()
                                                                      {
                {this.buttonOne, this.buttonOne.Text},
                {this.buttonTwo, this.buttonTwo.Text}
                                                                      };
        }
        private void buttonTwo_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (this.currentButton != null)
            {
                this.currentButton.Enabled = true;
                this.currentButton.Text = this.initialButtonInscriptions[this.currentButton];
                this.currentButton.Click += this.buttonTwo_Click;
                tm2.Enabled = false;
                tm2.Tick -= timer2_Tick;
            }
            
            this.currentButton = button;
            var saying = this.correspondingControls[button];
            saying.Visible = true;
            button.Text = "Click To Hide Saying";
            button.Click -= buttonTwo_Click;
            button.Click += buttonTwo_Click2;
        }
        private void buttonTwo_Click2(object sender, EventArgs e)
        {
            var button = sender as Button;
            var saying = this.correspondingControls[button];
            saying.Visible = true;
            if (saying.Visible)
            {
                button.Enabled = false;
                saying.Visible = false;
                button.Text = "Reactivating in 5 seconds";
                tm2.Interval = 1000;
                button.Click -= buttonTwo_Click2;
                button.Click += buttonTwo_Click;
                this.ii = 4;
                tm2.Tick += timer2_Tick;
                tm2.Enabled = true;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ii != 0)
            {
                this.currentButton.Text = "Reactivating in " + ii + " seconds";
                ii -= 1;
            }
        }
