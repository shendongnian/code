        public static void Logout()
		{
			foreach (Form frm in Application.OpenForms)
			{
				if (frm.GetType() != typeof(Login))
				{
					frm.Hide();
					logoutIdleUser = true;
				}
			}
			if (logoutIdleUser)
			{
				new Login().Show();
				MessageBox.Show("You will be logged out.", "Session Expired!");
			}
		}
