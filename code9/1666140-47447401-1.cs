        <ListView x:Name="list">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="HorizontalContentAlignment" Value="Stretch" />
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <TextBlock ... />
                        <Image Grid.Column="1" HorizontalAlignment="Right" ... />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
