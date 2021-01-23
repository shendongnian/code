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
				var users = File.ReadAllLines("Customer.txt")
					.Select(line => new { login = line[0], password = line[1] })
					.ToList();
			    attempts++;
				if (users.Any(user => user.login == txtName.Text && user.password == pbPassword.Password))
				{
					MainWindow mainWindow = new MainWindow();
					this.Hide();
					mainWindow.ShowDialog();
					return;
				}
				else
				{
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
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
			}
		}
	}
