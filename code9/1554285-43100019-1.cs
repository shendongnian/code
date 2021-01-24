    <Grid x:Name="Container">
        <Grid.DataContext>
            <wpfDemos:Board Rows="8" Columns="8"/>
        </Grid.DataContext>
        <ItemsControl x:Name="Board" ItemsSource="{Binding Path=Cells}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate >
                    <UniformGrid Rows="{Binding Path=Rows}" Columns="{Binding Path=Columns}"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Button Content="{Binding Path=Sign}" 
                            IsEnabled="{Binding Path=CanSelect}"
                            Click="CellClick"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
