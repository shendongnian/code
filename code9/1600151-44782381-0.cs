            <ComboBox x:Name="cmb">
            <ComboBox.Style>
                <Style TargetType="ComboBox">
                    <Setter Property="ItemTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <TextBlock>
                                    <TextBlock.Text>
                                        <MultiBinding Converter="{StaticResource multi}">
                                            <Binding Path="."/>
                                            <Binding Path="SelectedItem" ElementName="cmb"/>
                                        </MultiBinding>
                                    </TextBlock.Text>
                                </TextBlock>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
            </ComboBox.Style>
            <ComboBox.Items>
                <sys:String>Very long string 1</sys:String>
                <sys:String>Very long string 2</sys:String>
            </ComboBox.Items>
        </ComboBox>  
