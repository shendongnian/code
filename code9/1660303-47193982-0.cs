    <GridViewColumn  GridViewColumn Header="State" Width="52" >
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding state}">
                                        <TextBlock.Style>
                                            <Style TargetType="{x:Type TextBlock}">
                                                <Setter Property="TextBlock.Foreground" Value="Black"></Setter>
                                                <Style.Triggers>
    												<DataTrigger Binding="{Binding TextBlock.Text}" Value="Pass">
    													<Setter Property="TextBlock.Foreground" Value="Blue"/>
    												</DataTrigger>
    												<DataTrigger Binding="{Binding TextBlock.Text}" Value="Fail">
    													<Setter Property="TextBlock.Foreground" Value="Red"/>
    												</DataTrigger>
    											</Style.Triggers>
                                            </Style>
                                        </TextBlock.Style>
                                    </TextBlock>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
