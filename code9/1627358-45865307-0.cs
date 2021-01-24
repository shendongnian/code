    <telerik:GridViewDataColumn Name="MyCheckBoxColumn">
        <telerik:GridViewDataColumn.CellTemplate>
            <DataTemplate>
                <CheckBox Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type telerik:GridViewDataControl}}, Path=DataContext.IncludeChangedCommand}" 
                          CommandParameter="{Binding}"
                          IsChecked="{Binding MyBooleanProperty, Mode=TwoWay}" />
            </DataTemplate>
        </telerik:GridViewDataColumn.CellTemplate>
    </telerik:GridViewDataColumn>
