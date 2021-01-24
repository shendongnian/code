    var L1 = new List<int> {1, 2, 3, 4, 5};
    var L2 = new List<int> {1, 2, 0, 4, 5};
    var results = L1.Zip(L2, (i, j) => new {Previous = i, Current = j, IsDifferent = i != j});
    ListResults.ItemsSource = results;
<!---->
    <ItemsControl Name="ListResults">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <UniformGrid Rows="1">
                    <UniformGrid.Style>
                        <Style TargetType="UniformGrid">
                            <Style.Triggers>
                              <DataTrigger Binding="{Binding Path=IsDifferent}" Value="true">
                                <Setter Property="Background" Value="Crimson"/>
                              </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </UniformGrid.Style>
                    <Label Content="{Binding Path=Previous}"/>
                    <Label Content="{Binding Path=Current}"/>
                </UniformGrid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
