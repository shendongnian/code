xmlns:sys="clr-namespace:System;assembly=mscorlib"
        <Style.Triggers>
                <DataTrigger>
                    <DataTrigger.Binding>
                        <Binding Path="WorkLoad" Converter="{StaticResource capacityConverter}">
                            <Binding.ConverterParameter>
                                <sys:Int32>12</sys:Int32>
                            </Binding.ConverterParameter>
                        </Binding>
                    </DataTrigger.Binding>
                    <DataTrigger.Value>
                        <sys:Boolean>true</sys:Boolean>
                    </DataTrigger.Value>
                    <Setter Property="Fill" Value="Red"/>
                </DataTrigger>
        </Style.Triggers>
