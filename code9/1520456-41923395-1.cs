    <Style x:Key="MyStyle" TargetType="ContentControl">
        <Style.Resources> <!-- must put resource here -->
            <converters:ThicknessConverter x:Key="ThicknessConverter"/>
            <ns:ThicknessList x:Key="ThicknessModifier"> <!-- wrapper list instead of x:Array -->
                <!--Thickness Coefficient-->
                <Thickness>-0.5</Thickness>
                <!--Thickness Offset-->
                <Thickness>0,2</Thickness>
            </ns:ThicknessList>
        </Style.Resources>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ContentControl">
                    <Border Background="Black" Width="16" Height="16">
                        <Border.Margin>
                            <Binding Path="Width"
                                         RelativeSource="{RelativeSource Self}"
                                         Converter="{StaticResource ThicknessConverter}"
                                         ConverterParameter="{StaticResource ThicknessModifier}"/>
                        </Border.Margin>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
