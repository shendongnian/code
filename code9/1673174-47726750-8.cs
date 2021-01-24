    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class LabelAlgorithm : Form
        {
            public List<int> numbers = new List<int>();
            
            public LabelAlgorithm()
            {
                numbers.Add(1);
                numbers.Add(1);
                numbers.Add(1);
                numbers.Add(3);
                numbers.Add(5);
                numbers.Add(9);
                
                InitializeComponent();
                numbersLabel.Text = string.Join(", ", numbers);
            }
    
            private void SubmissionButton_Click(object sender, EventArgs e)
            {
                int x = numbers[numbers.Count - 1];
                int y = numbers[numbers.Count - 2];
                int z = numbers[numbers.Count - 3];
    
                int result = x + y + z;
    
                numbers.Add(result);
    
                numbersLabel.Text = string.Join(", ", numbers);
    
    
            }
        }
    }
 
