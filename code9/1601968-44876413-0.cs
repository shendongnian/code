    namespace Passing_Data
    {
    public partial class Form1 : Form
    {
        private double maxNum;
        public Form1()
        {
            InitializeComponent();
        }
        private double max(double num1, double num2, double num3)
        {
            if (num1 >= num2 && num1 >= num3)
            {
                maxNum = num1;
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                maxNum = num2;
            }
           else if (num3 >= num1 && num3 >= num2)
            {
                maxNum = num3;
            }
            return maxNum;
        }
        private void retBtn_Click(object sender, EventArgs e)
        {
            double num1, num2, num3;
            num1 = double.Parse(num1Box.Text);
            num2 = double.Parse(num2Box.Text);
            num3 = double.Parse(num3Box.Text);
            maxNum = max(num1, num2, num3);
            ansBox.Text = maxNum.ToString();
        }
