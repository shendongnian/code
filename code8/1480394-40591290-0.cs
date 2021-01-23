    public Form1()
    {
        this.panel1.ControlRemoved += this.Panel1_ControlRemoved;
    }
    
    private void Panel1_ControlRemoved(object sender, ControlEventArgs e)
    {
        int padding = 3;
        int lastRight = 0;
    
        foreach ( Control child in this.panel1.Controls ) 
        {
            child.Left = padding + lastRight;
            lastRight = child.Right + padding;
        }
    }
