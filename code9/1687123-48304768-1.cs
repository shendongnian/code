     public Form1()
            {
                InitializeComponent();
                foreach (Control c in this.Controls)
                {
                    ElementHost e = c as ElementHost;
                    if (e != null)
                    {
    
                        TP1WPFControls.TP1CustomButton btWPF = e.Child as TP1CustomButton;
                        if (btWPF != null)
                        {
    
                            //bt.bt.MouseLeave += Bt_MouseLeave;
                            //bt.lbl.MouseLeave += Lbl_MouseLeave;
                            btWPF.MouseLeave += Bt_MouseLeave;
                        }
                    }
                }
    
              
            }
       private void Bt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
            {
                TP1CustomButton btCustom = sender as TP1CustomButton;
    
               
                brushcolor = new brushColor(mediaColor.FromRgb(221, 247, 190));
                btCustom.bt.Background = brushcolor;
                btCustom.lbl.Background = brushcolor;
               
            }
