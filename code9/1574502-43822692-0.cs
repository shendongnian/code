        Log log = Log.GetInstance; //singleton
    private void Work()
            {
                while (true) { //changing log }
            }   
    
    private async void Represent()
            {
                await Task.Run(() =>
                {
                    while (true)     
                    {   
                        String str = String.Empty;
                        //generating str from log
                       this.Invoke(new Action(() => { textBox.Text = str;}));
                    } 
                });
            }
    
    private async void button_Click(object sender, EventArgs e)
            {
                await Task.Run(() => Work());
            }
    public MainForm()
            {
                Represent();
            }
