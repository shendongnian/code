        <Style x:Key="style1" TargetType="ListView">
        <Setter Property="View">
            <Setter.Value>
                <GridView>
                    <GridViewColumn Width="100"
                                    DisplayMemberBinding="{Binding one}"
                                    Header="1">
                        <GridViewColumn.HeaderContainerStyle>
                            <Style TargetType="GridViewColumnHeader">
                                <Style.Triggers>
                                    <Trigger Property="local:TestClass.Flag" Value="True">
                                        <Setter Property="Foreground" Value="Red" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </GridViewColumn.HeaderContainerStyle>
                    </GridViewColumn>
                    <GridViewColumn Width="100"
                                    DisplayMemberBinding="{Binding two}"
                                    Header="2" >
                        <GridViewColumn.HeaderContainerStyle>
                            <Style TargetType="GridViewColumnHeader">
                                <Style.Triggers>
                                    <Trigger Property="local:TestClass.Flag" Value="True">
                                        <Setter Property="Foreground" Value="Red" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </GridViewColumn.HeaderContainerStyle>
                    </GridViewColumn>
                </GridView>
            </Setter.Value>
        </Setter>
        <EventSetter Event="GridViewColumnHeader.Click" Handler="ColumnHeader_Click" />
    </Style>
