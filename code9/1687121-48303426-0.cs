    foreach (System.Windows.Forms.Control e in this.Controls)
    {        
        ElementHost c= e as ElementHost;
        if ( c != null ) 
        {
            TP1WPFControls.TP1CustomButton bt = c.Child as TP1CustomButton;
            if ( bt != null )
            {
                    // Add Events (I'd assume it would just be bt.MouseEnter but I don't know what your control looks like)
                    bt.bt.MouseEnter += Bt_MouseEnter;    
                    bt.bt.MouseLeave += Bt_MouseLeave;
            }
        }
    }
