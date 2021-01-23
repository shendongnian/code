    public partial class Form1 : Form
        {
            internal Drink Coke = new Drink();
            public Form1()
            {
                InitializeComponent();
                Coke.Name = (string)Cola[0, 0];
                Coke.Price = (float)Cola[0, 1];
                Coke.Amount = (int)Cola[0, 2];
            }
        }
