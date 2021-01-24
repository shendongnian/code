    enum Operators
    {
        NewOperation = -1,
        NotSet = 0,
        Plus = 1,
        Minus = 2
        //...
    };
    int value1, value2;
    const string RESET_VALUE = "0";
    Operators operation;
    public MainWindow() { InitializeComponent(); }
    private void MainWindow_Load(object sender, EventArgs e) { textresult.Text = RESET_VALUE; }
    private void button1_Click(object sender, EventArgs e) { AppendNumber(1); }
    private void button2_Click(object sender, EventArgs e) { AppendNumber(2); }
    private void button3_Click(object sender, EventArgs e) { AppendNumber(3); }
    private void button4_Click(object sender, EventArgs e) { AppendNumber(4); }
    private void button5_Click(object sender, EventArgs e) { AppendNumber(5); }
    private void button6_Click(object sender, EventArgs e) { AppendNumber(6); }
    private void button7_Click(object sender, EventArgs e) { AppendNumber(7); }
    private void button8_Click(object sender, EventArgs e) { AppendNumber(8); }
    private void button9_Click(object sender, EventArgs e) { AppendNumber(9); }
    private void button0_Click(object sender, EventArgs e) { AppendNumber(0); }
    private void AppendNumber(int selected_number)
    {
        if (operation == Operators.NewOperation)
        {
            operation = Operators.NotSet;
            textresult.Text = $"{selected_number}";         
        }
        else if (textresult.Text.StartsWith("0")) 
        { 
            textresult.Text = $"{selected_number}"; 
        }
        else 
        { 
            textresult.Text = $"{textresult.Text}{selected_number}";
        }
        if (operation == Operators.NotSet)
            value1 = int.Parse(textresult.Text);
        else
            value2 = int.Parse(textresult.Text);
    }
    private void buttonPlus_Click(object sender, EventArgs e)
    {
        operation = Operators.Plus;
        textresult.Text = RESET_VALUE;
    }
    private void buttonMinus_Click(object sender, EventArgs e)
    {
        operation = Operators.Minus;
        textresult.Text = RESET_VALUE;
    }
    private void buttonIs_Click(object sender, EventArgs e)
    {
        switch (operation)
        {
            case Operators.Minus: textresult.Text = $"{(value1 - value2)}"; break;
            case Operators.Plus: textresult.Text = $"{(value1 + value2)}"; break;
        }
        operation = Operators.NewOperation;
        value1 = int.Parse(textresult.Text); //save result for next operation
        value2 = 0;
    }
    private void buttonClear_Click(object sender, EventArgs e)
    {
        operation = Operators.NotSet;
        textresult.Text = RESET_VALUE;
        value1 = value2 = 0;
    }
