    <Expander.Style>
        <Style TargetType="Expander">
            <Style.Triggers>
                <Trigger Property="IsExpanded" Value="True">
                    <Setter Property="Header">
                        <Setter.Value>
                            <DockPanel>
                                <TextBlock FontWeight="Bold" Text="{Binding Name}" />
                            </DockPanel>
                        </Setter.Value>
                    </Setter>
                </Trigger>
                <Trigger Property="IsExpanded" Value="False">
                    <Setter Property="Header">
                        <Setter.Value>
                            <DockPanel>
                                <TextBlock FontWeight="Bold">
                                  <TextBlock.Inlines>
                                     <Run Text="{Binding Name}"/>
                                     <Run Text=" ( "/>
                                       <Run Text="{Binding Name, Converter={StaticResource ItemCountCnvKey}}" />
                                     <Run Text=" ) "/>
                                  </TextBlock.Inlines>
                                </TextBlock>
                            </DockPanel>
                        </Setter.Value>
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Expander.Style>
