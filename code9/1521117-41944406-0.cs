            public float a;
            public float b;
            public float c;
            public float d;
            public float f;
    
            public void cmbSubClass_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmbSubClass.SelectedIndex == 0)
                {
                    txtOutput.Text = ("class1 selected");
                    a = 1.12F;
                    b = 2.32F;
                    c = 3.32F;
                    d = 4.31F;
                    f = 5.23F;
                    
                }
                if (cmbSubClass.SelectedIndex == 1)
                {
                    txtOutput.Text = ("class2 selected");
                    a = 0.01F;
                    b = 0.21F;
                    c = 0.23F;
                    d = 0.75F;
                    f = 1.66F;
                }
                if (cmbSubClass.SelectedIndex == 2)
                {
                    txtOutput.Text = ("class3 selected");
                    a = 1.02F;
                    b = 1.22F;
                    c = 1.42F;
                    d = 1.62F;
                    f = 1.32F;
    
                }
            }
