           <Style TargetType="{x:Type TextBox}">
                <Style.Triggers>
                    <Trigger Property="Validation.HasError" Value="True">
                        <Setter Property="ToolTip">
                            <Setter.Value>
                                <ToolTip DataContext="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget}">
                                    <ItemsControl DisplayMemberPath="ErrorContent" ItemsSource="{Binding Path=(Validation.Errors)}" />
                                </ToolTip>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
