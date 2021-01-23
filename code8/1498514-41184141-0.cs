      <Grid>
            <Grid.Resources>
                <DataTemplate DataType="{x:Type my:AdvancedViewModel}">
                    <view:AdvancedView/>
                </DataTemplate>
                <DataTemplate DataType="{x:Type my:RegularViewModel}">
                    <view:RegularView/>
                </DataTemplate>
            </Grid.Resources>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <ListBox ItemsSource="{Binding ViewModels}" SelectedItem="{Binding SelectedViewModel}" Grid.Column="0"/>
            <ContentControl Content="{Binding SelectedViewModel}" Grid.Column="1"/>
        </Grid>
