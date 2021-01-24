    <UserControl x:Class="WpfApplication2.FuzzyInnerTableControl"
                 ...
                 Loaded="UserControl_Loaded">
        <UserControl.Resources>
            <viewModel:FuzzyInnerTableViewModel x:Key="defaultVM"/>
        </UserControl.Resources>
        <DataGrid ItemsSource="{Binding DataTable}"/>
    </UserControl>
