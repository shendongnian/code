    <GridViewColumn Width="150">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <TextBlock x:Name="Txt2" Text="{Binding data2}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding data2}" Value="7">
                                    <Setter Property="Foreground" Value="Red"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                <TextBlock/>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
        <GridViewColumn.Header>
            <GridViewColumnHeader Tag="Data2">
                <TextBlock>Data 2</TextBlock>
            </GridViewColumnHeader>
        </GridViewColumn.Header>
    </GridViewColumn>
