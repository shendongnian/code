    class Test : Form
    {
        private Button btn;
        private TextBox textBox;
        public Test()
        {
            btn = new Button();
            btn.Text = "Click Me";
            btn.Parent = this;
            btn.Location = new Point(100, 10);
            btn.Click += ButtonOnClick;
            this.Controls.Add(btn);
            textBox = new TextBox();
            textBox.Parent = this;
            textBox.Size = new Size(150, 25);
            textBox.Location = new Point(60, 60);
            this.Controls.Add(textBox);
        }
        void ButtonOnClick(object objSrc, EventArgs args)
        {
           String message = textBox.Text;
           // This will be written to the Output Window when you debug inside
           // Visual Studio or totally lost if you run the executable by itself
           //Console.WriteLine(message);
           // WinForms uses MessageBox.Show
           MessageBox.Show(message);
        }
    }
