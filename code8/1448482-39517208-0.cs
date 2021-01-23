    <TextBox>
    	<TextBox.CommandBindings>
    		<CommandBinding Command="Paste" Executed="CommandBinding_Executed"/>
    	</TextBox.CommandBindings>
    </TextBox>
<!---->
	private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
	{
		e.Handled = true;
	}
