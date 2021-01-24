                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding IsChecked, ElementName=scientist}" Value="false"/>
                        <Condition Binding="{Binding IsChecked, ElementName=writer}" Value="false"/>
                        <Condition Binding="{Binding IsChecked, ElementName=programmer}" Value="false"/>
                    </MultiDataTrigger.Conditions>
                    <Setter Property="IsEnabled" Value="False"/>
                </MultiDataTrigger>
