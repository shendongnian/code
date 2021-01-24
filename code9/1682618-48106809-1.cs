            <Style x:Key="Panel" TargetType="DockPanel">
                <Setter Property="Opacity" Value="0"/>
                <Style.Triggers>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="Background" Value="Black" />
                            <Condition Property="IsMouseOver" Value="True"/>
                        </MultiTrigger.Conditions>
                        <MultiTrigger.Setters>
                            <Setter Property="Opacity" Value="1" />
                        </MultiTrigger.Setters>
                    </MultiTrigger>
                </Style.Triggers>
            </Style>
