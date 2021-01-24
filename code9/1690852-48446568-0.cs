    <DataGrid x:Name="dg" AutoGenerateColumns="False">
        <DataGrid.CellStyle>
            <Style TargetType="DataGridCell">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DataGridCell}">
                            <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                                <ContentPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}">
                                    <ContentPresenter.InputBindings>
                                        <MouseBinding Gesture="LeftDoubleClick"
                                                      Command="{Binding DataContext.DoubleClickCommand,RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                                    </ContentPresenter.InputBindings>
                                </ContentPresenter>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.CellStyle>
        <DataGrid.InputBindings>
            <MouseBinding Gesture="LeftDoubleClick" Command="{Binding DoubleClickCommand}"/>
        </DataGrid.InputBindings>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
        </DataGrid.Columns>
    </DataGrid>
