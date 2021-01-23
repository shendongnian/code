    public partial class UserAndPin : Window
    {
		short attempts;
        public UserAndPin()
        {
            InitializeComponent();
			attempts = 0;
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("Customer.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineArray = line.Split(';');
                    if (lineArray[0] == txtName.Text & lineArray[1] == pbPassword.Password)
                    {
                        MainWindow mainWindow = new MainWindow();
                        this.Hide();
                        mainWindow.ShowDialog();
                        //return;
                    }
                    else
                    {
                        attempts++;
                        if (attempts < 3)
                        {
                            MessageBox.Show("The NAME or PIN is incorect, you have " + (3 - attempts) + " attemps more");
                        }
                        if (attempts >= 3)
                        {
                            MessageBox.Show("Please try again later");
                            this.Close();
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
