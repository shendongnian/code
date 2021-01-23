    <Style TargetType="DataGridCell">
                                    <Setter Property="Foreground" Value="Black"/>
                                    <Setter Property="Background">
                                        <Setter.Value>
                                            <MultiBinding Converter="{StaticResource NameToBrushMultiValueConverter}" >
                                                <MultiBinding.Bindings>
                                                    <Binding RelativeSource="{RelativeSource AncestorType=Window}" Path="DataContext"/>
                                                    <Binding RelativeSource="{RelativeSource AncestorType=DataGrid}"></Binding>
                                                    <Binding RelativeSource="{RelativeSource Self}"/>
                                                </MultiBinding.Bindings>
                                            </MultiBinding>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
