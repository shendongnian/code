    <Page.DataContext>
      <vm:FacultyViewModel x:Name="ViewModel" />
    </Page.DataContext>
    <!-- Master --> 
    <Grid>
      <Grid.ColumnDefinitions>
          <ColumnDefinition Width="100" />
          <ColumnDefinition />
      </Grid.ColumnDefinitions>
    <ListView ItemSource="{Binding FacultyList}"  Grid.Column="0" 
         SelectedItem="{Binding SelectedFaculty, Mode=TwoWay}" >
       <ListView.ItemTemplate>
           <DataTemplate>
               <Grid>
                 <TextBlock Text="{Binding Name}" />
               </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
     </ListView>
     <!-- Details -->
     <Grid Grid.Column="1"
       <Grid.RowDefinitions>
         <RowDefinition />
         <RowDefinition />
         <RowDefinition />
         <RowDefinition />
       </Grid.RowDefinitions>
       <TextBlock Text="{Binding SelectedPerson.name}" />
       <TextBlock Text="{Binding SelectedPerson.username }" Grid.Row="1" />
       <TextBlock Text="{Binding SelectedPerson.title}" Grid.Row="2" />
    </Grid>
