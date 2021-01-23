		<Window.Resources>
			<ResourceDictionary>
				<ResourceDictionary.MergedDictionaries>
					<ResourceDictionary Source="Skins/MainSkin.xaml" />
				</ResourceDictionary.MergedDictionaries>
			</ResourceDictionary>
		</Window.Resources>
		<Grid x:Name="LayoutRoot">
			<myname:UserControl1 IsEnabled="{Binding IsEnabled}" Margin="105,25,112,210"/>
		<myname:UserControl2 Margin="88,90,112,145"/>
		</Grid>
	</Window>
