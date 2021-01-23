	public class BrowseForFolderEditor : DialogPropertyValueEditor
	{
		public BrowseForFolderEditor()
		{
			// Create a textbox, a '...' button and a tooltip.
			string template = @"
				<DataTemplate
					xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
					xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
					xmlns:pe='clr-namespace:System.Activities.Presentation.PropertyEditing;assembly=System.Activities.Presentation'>
					<DockPanel LastChildFill='True'>
						<pe:EditModeSwitchButton TargetEditMode='Dialog' Name='EditButton' DockPanel.Dock='Right'>...</pe:EditModeSwitchButton>
						<TextBlock Text='{Binding Value}' Margin='2,0,0,0' VerticalAlignment='Center'>
							<TextBox.ToolTip>
								<ToolTip>
									<TextBlock Text='{Binding Value}' Margin='2' VerticalAlignment='Center' HorizontalAlignment='Left'/>
								</ToolTip>
							</TextBox.ToolTip>
						</TextBlock>
					</DockPanel>
				</DataTemplate>";
			using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(template)))
			{
				this.InlineEditorTemplate = XamlReader.Load(sr) as DataTemplate;
			}
		}
		public override void ShowDialog(PropertyValue propertyValue, 
          IInputElement commandSource)
		{
			var browse = new FolderBrowserDialog
			{
				ShowNewFolderButton = true,
				SelectedPath = propertyValue.StringValue,
				Description = "Select Target Folder:",
				RootFolder = Environment.SpecialFolder.MyComputer
			};
			if (browse.ShowDialog() == DialogResult.OK)
			{
				propertyValue.Value = browse.SelectedPath;
			}
			browse.Dispose();
		}
	}
