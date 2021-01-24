    <telerik:GridViewDataColumn Header="Description" Width="180">
        <telerik:GridViewDataColumn.CellTemplate>
            <DataTemplate>
                <telerik:RadComboBox IsEditable="True" 
                    ItemsSource="{Binding SLStandardDescriptions}" 
                    Text="{Binding Description1,Mode=TwoWay}"     >
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="DropDownOpened">
                            <i:InvokeCommandAction Command="{Binding DataContext.SLStandardDescriptionsDropDownOpenedCommand, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </telerik:RadComboBox>
            </DataTemplate>
        </telerik:GridViewDataColumn.CellTemplate>
    
    </telerik:GridViewDataColumn>
