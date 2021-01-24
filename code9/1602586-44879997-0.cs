    <ListView x:Name="_lstMenu" VerticalOptions="FillAndExpand" BackgroundColor="Transparent">
    		<ListView.ItemTemplate>
    			<DataTemplate>
    				<ViewCell>
    					<Grid>
    						<Grid.ColumnDefinitions>
    							<ColumnDefinition Width="2*"/>
    							<ColumnDefinition Width="6*"/>
    							<ColumnDefinition Width="2*"/>
    						</Grid.ColumnDefinitions>
    						<Image Source="{Binding IconSource}" IsVisible="{Binding isEnglish}"/>
    						<Label Grid.Column="1" Text="{Binding Title}" VerticalTextAlignment="Center" HorizontalTextAlignment="{Binding alignment}"/>
    						<Image Grid.Column="2" Source="{Binding IconSource}" IsVisible="{Binding isArabic}"/>
    					</Grid>
    				</ViewCell>
    			</DataTemplate>
    		</ListView.ItemTemplate>
    </ListView>
