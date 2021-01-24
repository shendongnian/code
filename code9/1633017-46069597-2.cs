    <TextBox Margin="20,3,5,13" Text="{Binding DOB, UpdateSourceTrigger=PropertyChanged, NotifyOnSourceUpdated=True}" MinWidth="120" materialDesign:HintAssist.Hint="Birthdate"  Style="{StaticResource MaterialDesignFloatingHintTextBox}" SourceUpdated="TextBox_SourceUpdated"/>
    		private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			var txtBx = sender as TextBox;
			if (txtBx == null || txtBx.Text==null) return;			
			if (txtBx.CaretIndex == 2 || txtBx.CaretIndex == 5)
			{
				txtBx.CaretIndex = txtBx.CaretIndex + 1;
			}
		}
