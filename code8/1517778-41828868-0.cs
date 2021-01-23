                <Style TargetType="{x:Type GridViewColumnHeader}" >
                    <Setter Property="Margin" Value="0,0,0,10"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="GridViewColumnHeader">
                                <Border BorderBrush="{Binding BorderBrush, RelativeSource={RelativeSource FindAncestor, AncestorType=ListView}}" BorderThickness="{Binding BorderThickness, RelativeSource={RelativeSource FindAncestor, AncestorType=ListView}}">
                                    <ContentPresenter  />
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
                <Style TargetType="ListView">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListView">
                                <ScrollViewer Style="{DynamicResource
                                              {x:Static GridView.GridViewScrollViewerStyleKey}}">
                                    <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}">
                                        <ItemsPresenter />
                                    </Border>
                                </ScrollViewer>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
