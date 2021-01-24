    <ItemsControl ItemsSource="{Binding Path=MyLabelList}">
        <ItemsPanelTemplate>
            <Grid>
                <Grid.ColumnDefinitions>
                    <!-- Add here -->
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <!-- Add here -->
                </Grid.RowDefinitions>
            </Grid>
        </ItemsPanelTemplate>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding content}" Style="{StaticResource MyLabel}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Row" Value="{Binding rowNr}" />
                <Setter Property="Grid.Column" Value="{Binding columnNr}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
