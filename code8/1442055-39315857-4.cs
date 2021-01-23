    <DataGrid ItemsSource="{Binding Collection}" 
              AutoGeneratingColumn="dataGrid_AutoGeneratingColumn">
        <DataGrid.Resources>
            <Style x:Key="CheckBoxColumnHeaderStyle" 
                   TargetType="{x:Type DataGridColumnHeader}">
                <Setter Property="LayoutTransform">
                    <Setter.Value>
                        <RotateTransform Angle="270"/>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
