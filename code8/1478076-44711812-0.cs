      <Style x:Key="CardsRowStyle" TargetType="{x:Type DataGridRow}">
        <Setter Property="local:ItemsView.DoubleClickCommand" Value="{Binding ItemDoubleClickCommand,RelativeSource={RelativeSource AncestorType=local:ItemsView}}" />
        <Setter Property="IsSelected" Value="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" />
        <Setter Property="Margin" Value="2.5" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type DataGridRow}">
                    <Border x:Name="DGR_Border"
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}"
                        Background="{TemplateBinding Background}"
                        SnapsToDevicePixels="True">
                        <DataGridDetailsPresenter Grid.Column="1"
                                                  Grid.Row="1"
                                                  Content="{Binding}"
                                                  ContentTemplate="{Binding CardTemplate,RelativeSource={RelativeSource AncestorType=local:ItemsView}}"
                                                  SelectiveScrollingGrid.SelectiveScrollingOrientation="{Binding AreRowDetailsFrozen, ConverterParameter={x:Static SelectiveScrollingOrientation.Vertical}, Converter={x:Static DataGrid.RowDetailsScrollingConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <!--  IsSelected  -->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <!--<Condition Binding="{Binding Path=(DataGridRowHelper.SelectionUnit), RelativeSource={RelativeSource Self}}" Value="FullRow" />-->
                    <Condition Binding="{Binding Path=IsSelected, RelativeSource={RelativeSource Self}}" Value="true" />
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource MetroDataGrid.HighlightBrush}" />
                <Setter Property="BorderBrush" Value="{DynamicResource MetroDataGrid.HighlightBrush}" />
                <Setter Property="Foreground" Value="{DynamicResource MetroDataGrid.HighlightTextBrush}" />
            </MultiDataTrigger>
            <!--  IsSelected and Selector.IsSelectionActive  -->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Path=(DataGridRowHelper.SelectionUnit), RelativeSource={RelativeSource Self}}" Value="FullRow" />
                    <Condition Binding="{Binding Path=IsSelected, RelativeSource={RelativeSource Self}}" Value="true" />
                    <Condition Binding="{Binding Path=(Selector.IsSelectionActive), RelativeSource={RelativeSource Self}}" Value="false" />
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource MetroDataGrid.InactiveSelectionHighlightBrush}" />
                <Setter Property="BorderBrush" Value="{DynamicResource MetroDataGrid.InactiveSelectionHighlightBrush}" />
                <Setter Property="Foreground" Value="{DynamicResource MetroDataGrid.InactiveSelectionHighlightTextBrush}" />
            </MultiDataTrigger>
            <!--  IsMouseOver  -->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Path=(DataGridRowHelper.SelectionUnit), RelativeSource={RelativeSource Self}}" Value="FullRow" />
                    <Condition Binding="{Binding Path=IsMouseOver, RelativeSource={RelativeSource Self}}" Value="true" />
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource MetroDataGrid.MouseOverHighlightBrush}" />
                <Setter Property="BorderBrush" Value="{DynamicResource MetroDataGrid.MouseOverHighlightBrush}" />
            </MultiDataTrigger>
            <!--  IsEnabled  -->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Path=(DataGridRowHelper.SelectionUnit), RelativeSource={RelativeSource Self}}" Value="FullRow" />
                    <Condition Binding="{Binding Path=IsEnabled, RelativeSource={RelativeSource Self}}" Value="false" />
                </MultiDataTrigger.Conditions>
                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
            </MultiDataTrigger>
            <!--  IsEnabled and IsSelected  -->
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding Path=(DataGridRowHelper.SelectionUnit), RelativeSource={RelativeSource Self}}" Value="FullRow" />
                    <Condition Binding="{Binding Path=IsEnabled, RelativeSource={RelativeSource Self}}" Value="false" />
                    <Condition Binding="{Binding Path=IsSelected, RelativeSource={RelativeSource Self}}" Value="true" />
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource MetroDataGrid.DisabledHighlightBrush}" />
                <Setter Property="BorderBrush" Value="{DynamicResource MetroDataGrid.DisabledHighlightBrush}" />
                <Setter Property="Foreground" Value="{DynamicResource MetroDataGrid.HighlightTextBrush}" />
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
 
