    <DataGrid.CellStyle>
       <Style TargetType="DataGridCell" BasedOn="{StaticResource {x:Type DataGridCell}}">
          <Style.Triggers>
             <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                   <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsKeyboardFocusWithin}" Value="True" />
                   <Condition Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGrid}, Path=DataContext.IsEditing}" Value="True" />
                </MultiDataTrigger.Conditions>
                <Setter Property="IsEditing"  Value="true" />
             </MultiDataTrigger>
          </Style.Triggers>
       </Style>
    </DataGrid.CellStyle>
