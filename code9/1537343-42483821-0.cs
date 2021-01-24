    <ComboBox.Style>
                                        <Style TargetType="ComboBox">
                                            <Setter Property="IsEnabled" Value="False"/>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridRow}}, Path=Item.Name }" Value="{x:Static sys:String.Empty}">
                                                    <Setter Property="IsEnabled" Value="True"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </ComboBox.Style>
