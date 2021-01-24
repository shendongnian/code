    <DataGrid Name="DataGrid" AutoGenerateColumns="False"  
                  Height="Auto" Width="780" Margin="10,10,10,10"
                  IsReadOnly="True" ItemsSource="{Binding Path=PreloadedRailcarstList}"
                  SelectedItem="{Binding Path=BaseProductToUpdate}"
                  AlternationCount="2" AlternatingRowBackground="LightBlue">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsOverFilled}" Value="True">
                        <Setter Property="Background" Value="Orange" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsOverWeighed}" Value="True">
                        <Setter Property="Background" Value="Orange" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.RowStyle>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseDoubleClick">
                <i:InvokeCommandAction Command="{Binding Path=DataContext.OpenUpdateBaseProductViewCmd , RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" CommandParameter="{Binding BaseProductToUpdate.name}"/>
            </i:EventTrigger>
            <i:EventTrigger EventName="PreviewKeyDown">
                <i:InvokeCommandAction Command="{Binding Path=DataContext.OpenUpdateBaseProductViewCmd , RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" CommandParameter="{Binding BaseProductToUpdate.name}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
        ...
    </DataGrid>
