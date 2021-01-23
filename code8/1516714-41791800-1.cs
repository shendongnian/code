    <Style x:Key="ShowHideStyle" TargetType="Expander" >
        <Style.Setters>
            <Setter Property="IsExpanded" Value="False" />
        </Style.Setters>
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Value="True">
                        <Condition.Binding>
                            <MultiBinding Converter="{StaticResource V_converter }">
                                <Binding Path="Type"></Binding>
                                <Binding Path="NodeID"></Binding>
                                <Binding Path="TLV"></Binding>
                            </MultiBinding>
                        </Condition.Binding>
                    </Condition>
                </MultiDataTrigger.Conditions>
                <MultiDataTrigger.Setters>
                    <Setter Property="IsExpanded" Value="True" />
                </MultiDataTrigger.Setters>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
