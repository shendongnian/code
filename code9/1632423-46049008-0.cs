    public partial class calculator : Form
    {
        public calculator()
        {
            InitializeComponent();
        }
           //assuming this is clicking the Add (+) Button
        private void btnInput_Click(object sender, EventArgs e)
        {
            double fNum = 0.0; //initialize a variable with default value
                               //if you didn't include 0.0 you will get a "local variable" error
            Calculations calculations = new Calculations();
            calculations.Total = Convert.ToInt32(txtPrice.Text);
            fNum = calculations.GetPrice();
            //take Note the below code will really just return the value you have just entered in your textbox since you didn't used calculations.GetPrice();
            //displayBox.Text = Convert.ToString(calculations.Total);
            //the below code will show the value you have entered added
            //to itself since the logic from your class is just Total+=Total
            // example I input 1. (so Total = 1) then fNum will be (Total = 1 + 1)
            // which is 2
            displayBox.Text = Convert.ToString(fNum);
 
        }   
    }
    public class Calculations
    {
        public int Total {get; set;} //Best practice to use CamelCase for properties inside a class
    
        public int GetPrice()
        {
            Total += Total;
    
            return Total;
        }        
    }
