    public partial class frmAddInventoryTransItem3 : MetroForm
        {
            public frmAddInventoryTrans ReceivingAdd { set; get; }
            public frmEditInventoryTrans ReceivingEdit { set; get; }
    
            string inv_type2 = null, action2 = null, document2 = null;
            private string weight;
            private SerialConnection sc = null;
    
            private void frmAddInventoryTransItem3_Load(object sender, EventArgs e)
            {
                txtQty.Text = 1.ToString();
                txtWeight.Text = 0.ToString("N3");
                this.ActiveControl = txtPLU;
                
                sc = SerialConnection.OpenConnection();
                sc.WeightReceived += new SerialDataReceivedEventHandler(WeightReceived);
            }
    
            private void WeightReceived(object weight, EventArgs e)
            {
                    weight = weight as string;
    
                    try
                    {
                        if (this.InvokeRequired)
                            this.BeginInvoke(new EventHandler(DisplayText));
                    }
                    catch (ObjectDisposedException) { }
            }
    
            private void DisplayText(object sender, EventArgs e)
            {
                txtWeight.Text = weight;
            }
        }
    }
