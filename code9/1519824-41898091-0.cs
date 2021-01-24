    public MainForm()
        {
            try
            {
                using(var _lForm=new LoginForm())
                {
    				_lForm.ShowDialog();
    				if (LoginForm._loginSuccess)
    				{
    					InitializeComponent();
    				}
    				else
    				{
    					this.Close();
    				}
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
