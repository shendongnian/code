        public partial class MainWindow : Window
    {
       int inputNumber;
        
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            
            if (int.TryParse(txtInput.Text, out inputNumber) )
            {
                TranslateNumber();
            }
            
        }
        private void TranslateNumber()
        {
            var unitsMap = new[] { " ", " One ", " Two ", " Three ", " Four ", " Five ", " Six ", " Seven ", " Eight ", " Nine ", " Ten ", " Eleven ", " Twelve ", " Thirteen ", " Fourteen ", " Fifteen ", " Sixteen ", " Seventeen ", " Eighteen ", " Nineteen " };
            var tensMap = new[] { " ", " Ten ", " Twenty ", " Thirty ", " Forty ", " Fifty ", " Sixty ", " Seventy ", " Eighty ", " Ninety " };
           
            if (inputNumber == 0)
            {
                tBlkOutput.Text += "zero";
            }
           
           
          
            if ((inputNumber / 1000000) > 0 )
            {
                if ((inputNumber / 100000000) > 0)
                {
                    // needs a number betwwen 1 and 9
                    tBlkOutput.Text += unitsMap[inputNumber / 100000000] + " Hundred and ";
                    inputNumber %= 100000000;
                }
                // need to be able to list between 1 million and 99 million
                if ((inputNumber / 10000000) > 0)
                {
                    tBlkOutput.Text += tensMap[inputNumber / 10000000];
                    inputNumber %= 10000000;
                }
                if ((inputNumber / 1000000) > 0)
                {
                    tBlkOutput.Text += unitsMap[inputNumber / 1000000];
                    inputNumber %= 1000000;
                }
                tBlkOutput.Text += " Million ";
            }
          
          
            if ((inputNumber / 1000) > 0)
            {
                if ((inputNumber / 100000) > 0)
                {
                    // needs a number betwwen 1 and 9
                    tBlkOutput.Text += unitsMap[inputNumber / 100000] + " Hundred and  ";
                    inputNumber %= 100000;
                }
                if ((inputNumber / 10000) > 0)
                {
                    tBlkOutput.Text += tensMap[inputNumber / 10000];
                    inputNumber %= 10000;
                }
                if ((inputNumber / 1000) > 0)
                {
                    tBlkOutput.Text += unitsMap[inputNumber / 1000];
                    inputNumber %= 1000;
                }
                tBlkOutput.Text += " Thousand ";
            }
            if ((inputNumber / 100) > 0)
            {
                tBlkOutput.Text += unitsMap[inputNumber / 100] + " Hundred and ";
                inputNumber %= 100;
            }
            if ((inputNumber / 10 ) > 0)
            {
                tBlkOutput.Text += tensMap[inputNumber / 10];
                inputNumber %= 10;
            }
            if (inputNumber > 0)
            {
                tBlkOutput.Text += unitsMap[inputNumber];
            }
        
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            tBlkOutput.Text = "";
            inputNumber = 0;
            txtInput.Text = "";
            txtInput.Focus();
        }
    }
