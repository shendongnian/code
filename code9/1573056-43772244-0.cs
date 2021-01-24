        private Dictionary<string, Action> _selectedActions = null;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.checkedListBox1.Items.Add("Apple");
            this.checkedListBox1.Items.Add("Banana");
            this.checkedListBox1.Items.Add("Cherry");
            _selectedActions = new Dictionary<string, Action>()
            {
                { "Apple", Apple },
                { "Banana", Banana },
                { "Cherry", Cherry },
            };
        }
        private void Apple() { MessageBox.Show("Ran Apple"); }
        private void Banana() { MessageBox.Show("Ran Banana"); }
        private void Cherry() { MessageBox.Show("Ran Cherry"); }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var action in this.checkedListBox1
                .CheckedItems
                .Cast<string>()
                .Select(x => _selectedActions[x]))
            {
                action();
            }
        }
