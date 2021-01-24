    <!-- 
    UpdateSourceTrigger=PropertyChanged tells the binding when to update the viewmodel 
    property. Well, a ListView cannot ever give your viewmodel a new collection of items,
    so don't bother giving it that flag. 
    -->
    <ListView ItemsSource="{Binding Detail.Students}">
        <ListView.Resources>
            <local:CountStudentCoursePointsConverter
                x:Key="CoursePointsConverter"
                />
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridView.Columns>
                    <GridViewColumn Width="60"  DisplayMemberBinding="{Binding Login}" />
                    <GridViewColumn Width="60" x:Name="Points">
                        <GridViewColumn.DisplayMemberBinding>
                            <MultiBinding Converter="{StaticResource CoursePointsConverter}">
                                <!-- 
                                No path gives us the row item itself, an instance of 
                                StudentListModel.
                                -->
                                <Binding />
                                <!-- 
                                The parent viewmodel is the DataContext of our ancestor 
                                control, the ListView. That's a CourseDetailViewModel. 
                                So go there with RelativeSource, get its Detail property,
                                and grab the Id.
                                -->
                                <Binding
                                    Path="DataContext.Detail.Id"
                                    RelativeSource="{RelativeSource AncestorType=ListView}"
                                    />
                            </MultiBinding>
                        </GridViewColumn.DisplayMemberBinding>
                    </GridViewColumn>
                </GridView.Columns>
            </GridView>
        </ListView.View>
    </ListView>
