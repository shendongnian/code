    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="50*"></RowDefinition>
            <RowDefinition Height="300*"></RowDefinition>
        </Grid.RowDefinitions>
        <TextBlock Text="Teacher list" FontSize="25" Grid.Row="0"></TextBlock>
        <ListView x:Name="listView" Grid.Row="1" ItemSource="{x:Bind listOfTeachers"}>
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="TeacherWithClasses">
                    <StackPanel Orientation="Vertical">
                        <TextBlock Text="{x:Bind Path=teacher.TeacherID}"></TextBlock>
                        <TextBlock Text="{x:Bind Path=teacher.TeacherName}"></TextBlock>
    					<TextBlock Text="Teaching class(es):"></TextBlock>
    					<ListView ItemSource="{x:Bind listOfClasses}">
    						<ListView.ItemTemplate>						
    							<DataTemplate x:DataType="Class">
    								<TextBlock Text="{x:Bind ClassName}" />
    							</DataTemplate>
    						</ListView.ItemTemplate>
    					</ListView>                    
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
    class TeacherWithClasses
    {
        public Teacher teacher;    
        List<Class> listOfClasses;
    	
    	public TeacherWithClasses(Teacher _teacher, List<Class> _listOfClasses)
    	{
    		teacher = _teacher;
    		listOfClasses = _listOfClasses;
    	}
    }
    class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    
        public Class() { }
    }
