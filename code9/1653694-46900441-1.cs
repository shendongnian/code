    xmlns:sys="clr-namespace:System;assembly=System" 
    <DataGrid.Columns>
            <DataGridTextColumn x:Name="dgcComments" Header="Comment" Width="*" Binding="{Binding Path=Comment, Mode=TwoWay, UpdateSourceTrigger=PropertyChange}">
                <DataGridColumn.ElementStyle>
                    <Style TargetType="TextBlock">
                        <Setter Property="TextWrapping" Value="Wrap" />
                        <Setter Property="Padding" Value="2,0,2,2" />
                        <Setter Property="TextAlignment" Value="Left" />
                    </Style>
                </DataGridColumn.ElementStyle>
                <DataGridColumn.EditingElementStyle>
                    <Style TargetType="TextBox">
                        <Setter Property="TextWrapping" Value="Wrap" />
                        <Setter Property="AcceptsReturn" Value="True" />
                        <Setter Property="Padding" Value="2,0,2,2" />
                        <Setter Property="TextAlignment" Value="Left" />
                        <Setter Property="MaxLength" Value="4000" />
                        <Setter Property="SpellCheck.IsEnabled" Value="True" />
                       <Setter Property="SpellCheck.CustomDictionaries">
                            <Setter.Value>
                                <sys:Uri>pack://application:,,,/customwords.lex</sys:Uri>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGridColumn.EditingElementStyle>
            </DataGridTextColumn>
            ...
        </DataGrid.Columns>
