        <Button Command="{Binding Command}" Text="Blah Button">
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                        <Trigger TargetType="Button"  Property="IsEnabled" Value="False">
                            <Setter Property="BackgroundColor" Value="Red"></Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
