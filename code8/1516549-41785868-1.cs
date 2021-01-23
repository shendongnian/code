	async private void btnCourse1_Click(object sender, RoutedEventArgs e)
    {
        string[] names = new string[3] { "COP3488C,", "UWP1,", "This course is mobile app development." };
		Worker(names);
    }
    async private void btnCourse2_Click(object sender, RoutedEventArgs e)
    {
        string[] names = new string[3] { "DOP3488B,", "UWC1,", "This course is Cloud Computing." };
		Worker(names);
    }
    async private void btnCourse3_Click(object sender, RoutedEventArgs e)
    {
        
        string[] names = new string[3] { "BOP3589,", "UWP2,", "This course Computer Programming Java 1." };
		Worker(names);
        
    }
	private async Task Worker(string[] names)
	{
			string VarOutput = "";
			
			for (int i = 0; i < names.Length; i++)
			{
				VarOutput = VarOutput + names[i] + "  ";
			}
			txtBoxCourse.Text = VarOutput;
			var dialog = new MessageDialog(VarOutput);
			await dialog.ShowAsync();
	}
