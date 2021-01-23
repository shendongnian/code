		<Window.Resources>
			<ResourceDictionary>
				<ResourceDictionary.MergedDictionaries>
					<ResourceDictionary Source="Skins/MainSkin.xaml" />
				</ResourceDictionary.MergedDictionaries>
			</ResourceDictionary>
		</Window.Resources>
		<Grid x:Name="LayoutRoot">
			<Button Command="{Binding EnableCommand}" Margin="115,75,120,160"/>
			<myname:UserControl1 IsEnabled="{Binding IsEnabled}" Margin="105,25,112,210"/>
		</Grid>
	</Window>
