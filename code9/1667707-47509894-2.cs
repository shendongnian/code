    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <ContentControl Content="{Binding}">
                <ContentControl.Style>
                    <Style TargetType="ContentControl">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding FileType}" Value="Image">
                                <Setter Property="ContentTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <Image Source="{Binding Path}"/>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding FileType}" Value="Text">
                                <Setter Property="ContentTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <TextBlock Text="{Binding Text}" />
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
            </ContentControl>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
