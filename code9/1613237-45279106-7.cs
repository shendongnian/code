     <Window.DataContext>
        <local:MainViewModel />
    </Window.DataContext>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="100"></ColumnDefinition>
            <ColumnDefinition Width="*"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <ListBox Grid.Column="0" ItemsSource="{Binding Items}" DisplayMemberPath="Name" SelectedItem="{Binding SelectedItem}"></ListBox>
        <Grid Grid.Column="1">
            <StackPanel Orientation="Vertical">
                <TextBox Text="{Binding SelectedItem.Name}" Height="30"/>
                <TextBox Text="{Binding SelectedItem.Height}" Height="30"/>
                <TextBox Text="{Binding SelectedItem.Width}" Height="30"/>
            </StackPanel>
        </Grid>
    </Grid>
