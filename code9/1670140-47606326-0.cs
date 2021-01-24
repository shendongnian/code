    private void add_Click(object sender, EventArgs e)
    {
    	double g = 0;
    	
        // Controls.OfType will automatically find your DynaItems controls and cast them for you
        foreach (DynaItems dynaItem in Controls.OfType<DynaItems>())
        {
            // Breakpoint here and check the value of dynaItem.price.Text
            g += double.Parse(dynaItem.price.Text);
        }
    
        textBox1.Text = g.ToString();
    }
