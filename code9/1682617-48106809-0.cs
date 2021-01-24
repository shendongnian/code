        <Style x:Key="Panel" TargetType="DockPanel">
            <Setter Property="Visibility" Value="Collapsed"/>
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Visibility" Value="Visible" />
                </Trigger>
                <Trigger Property="IsMouseOver" Value="False">
                    <Setter Property="Visibility" Value="Collapsed" />
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="Background" Value="Black"/>
                    </MultiTrigger.Conditions>
                    <MultiTrigger.Setters>
                        <Setter Property="Visibility" Value="Visible" />
                    </MultiTrigger.Setters>
                </MultiTrigger>
            </Style.Triggers>
        </Style>
