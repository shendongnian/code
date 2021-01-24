       <Setter Property="CommandParameter">
                                                        <Setter.Value>
                                                            <MultiBinding Converter="{StaticResource menuItemCommandConverter}">
                                                                <MultiBinding.Bindings>
                                                                    <Binding Path="DataContext" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}" />
                                                                    <Binding Path="Header" RelativeSource="{RelativeSource Mode=Self}" />
                                                                </MultiBinding.Bindings>
                                                            </MultiBinding>
                                                        </Setter.Value>
                                                    </Setter>
