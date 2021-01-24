       <!--System.Windows.Interactivity.WPF nuget package-->
       xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
 
        <DataGrid 
            ItemsSource="{Binding Accounts}"
            SelectedItem="{Binding SelectedAccount}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Loaded">
                    <i:InvokeCommandAction Command="{Binding LoadedCommand}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding AccountNumber}"/>
                <DataGridTextColumn Binding="{Binding LastName}" />
                <DataGridTextColumn Binding="{Binding FirstName}" />
            </DataGrid.Columns>
        </DataGrid>
