    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    		bookPriceLabels = new Label[] { lblBook1Price, lblBook2Price, lblBook3Price };
    	}
    	
    	private Label[] bookPriceLabels;
    
        private void btnPriceResults_Click(object sender, EventArgs e)
        {
            //VARIABLES
            double[] arrPrintPageNums = new double[3];
            double total = 0;
    
    
            //INPUTS
            arrPrintPageNums[0] = double.Parse(txtInputBook1.Text);
            arrPrintPageNums[1] = double.Parse(txtInputBook2.Text);
            arrPrintPageNums[2] = double.Parse(txtInputBook3.Text);
    		
    		Label[] labels = new Label
    
    
            //PROCESS (i = INDEX NUMBER(0 1 2 3 4))
            for (int i = 0; i < arrPrintPageNums.Length; i++)
            {		    
                if (arrPrintPageNums[i] > 0 && arrPrintPageNums[i] <= 500)
                {
                    bookPriceLabels[i].Text = "Print Cost: " + (arrPrintPageNums[i] * 2);
                    total += arrPrintPageNums[i] * 0.02;
                }
                else if (arrPrintPageNums[i] > 500 && arrPrintPageNums[i] <= 1000)
                {
                    bookPriceLabels[i].Text = "Print Cost: " + (arrPrintPageNums[i] * 1.5);
                    total += arrPrintPageNums[i] * 0.015;
                }
                else if (arrPrintPageNums[i] > 1000)
                {
                    bookPriceLabels[i].Text = "Print Cost: " + (arrPrintPageNums[i] * 1);
                    total += arrPrintPageNums[i] * 0.01;
                }
                else
                {
                    bookPriceLabels[i].Text = "ERROR! OUTSIDE PRINT RANGE" + "\n\n";
                }
    
            }
    
    
            //OUTPUT
            lblBookPriceTotal.Text = "Total price: " + total.ToString("C2");
        }
    }
