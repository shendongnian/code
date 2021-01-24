        void method1()
        {
            weight = Int32.Parse(weightTxt.Text);
            height = Int32.Parse(heightTxt.Text);
        } 
    
        void method2()
        {
            if (weight >= 300 || weight <= 10)
            {
                MessageBox.Show("Input not acceptable");
            }
        }
