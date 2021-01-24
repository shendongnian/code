    <UserControl x:Class="WpfApplication2.FuzzyTableControl"
                 ...
        >
        <UserControl.DataContext>
            <viewModel:FuzzyTableViewModel/>
        </UserControl.DataContext>
        <UserControl.Resources>
            <DataTemplate x:Key="FuzzyInnerTableTemplate">
                <view:FuzzyInnerTableControl
                    DataContext="{Binding Tag,RelativeSource={RelativeSource AncestorType=DataGridCell}}"/>
            </DataTemplate>
        </UserControl.Resources>
    
        <DataGrid AutoGenerateColumns="True" IsReadOnly="True"
            CanUserAddRows="False"
            CanUserDeleteRows="False"
            ItemsSource="{Binding DataTable}"
            AutoGeneratingColumn="DataGrid_AutoGeneratingColumn">
        </DataGrid>
    </UserControl>
