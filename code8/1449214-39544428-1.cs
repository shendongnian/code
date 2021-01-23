    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsChecked" Value="False"/>
            <Condition Property="IsMouseOver" Value="True"/>
        </MultiTrigger.Conditions>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate>
                    <Border BorderThickness="0">
                        <Image Source="C:\Users\Public\Pictures\Sample Pictures\koala.jpg" Height="41" Width="35"></Image>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </MultiTrigger>
