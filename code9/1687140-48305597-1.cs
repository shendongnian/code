     <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="agggsdf" ></TextBlock>
                                <Button Name="f"></Button>
                            </StackPanel>
                            <DataTemplate.Triggers>  
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Path=IsEditing}" Value="True">
                                        <Setter TargetName="f" Property="Content" Value="remove"></Setter>
                                        <Setter TargetName="f" Property="Style">
                                        <Setter.Value>
                                            <Style TargetType="Button">
                                                <EventSetter Event="Click" Handler="Button_Click"></EventSetter>
                                            </Style>
                                        </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Path=IsEditing}" Value="False">
                                    <Setter TargetName="f" Property="Content" Value="insert"></Setter>
                                    <Setter TargetName="f" Property="Style">
                                        <Setter.Value>
                                            <Style TargetType="Button">
                                                <EventSetter Event="Click" Handler="f_Click"></EventSetter>
                                            </Style>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </DataTemplate.Triggers>
                        </DataTemplate>
     </DataGridTemplateColumn.CellTemplate>
