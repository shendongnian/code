    <ComboBox ...>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <ContentControl Content="{Binding}">
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Setter Property="ContentTemplate" Value="{StaticResource NoParamTemplate}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Code}" Value="1">
                                    <Setter Property="ContentTemplate" Value="{StaticResource OneParamTemplate}" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding Code}" Value="2">
                                    <Setter Property="ContentTemplate" Value="{StaticResource TwoParamTemplate}" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
