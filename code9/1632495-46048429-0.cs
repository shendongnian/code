    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding ConditionValue}" Value="Y">
                                    <Setter Property="Text">
                                        <Setter.Value>
                                            <MultiBinding Converter="{StaticResource textMultiBindingConverter}">
                                                <Binding Path="AvailableQty " />
                                                <Binding Path="PrimaryUM"/>
                                            </MultiBinding>
                                        </Setter.Value>
                                    </Setter>
    
    
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
