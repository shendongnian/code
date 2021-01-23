    <DataGridTemplateColumn MinWidth="80" Width="1.25*" Header="6">
     <DataGridTemplateColumn.CellTemplate>
         <DataTemplate>
             <customControlls:NumericTextBox 
                     Style="{StaticResource NumericTextboxStyle}" 
                     Text="{Binding AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod, UpdateSourceTrigger=LostFocus}">
                 <interactivity:Interaction.Triggers>
                     <interactivity:EventTrigger EventName="LostFocus">
                        <interactions:CallMethodAction MethodName="LostFocus" TargetObject="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path=DataContext}" />
                     </interactivity:EventTrigger>
                 </interactivity:Interaction.Triggers>
             </customControlls:NumericTextBox>
         </DataTemplate>
     </DataGridTemplateColumn.CellTemplate>
