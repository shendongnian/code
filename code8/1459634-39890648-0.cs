    <StackPanel>
                    <RadioButton x:Name="RadioButton1" Content="1" />
                    <RadioButton x:Name="RadioButton2" Content="2" />
                    <RadioButton x:Name="RadioButton3" Content="3" />
                    <RadioButton x:Name="RadioButton4" Content="4" />
                    <RadioButton x:Name="RadioButton5" Content="5" />
    </StackPanel>
    <StackPanel Grid.Row="1">
                    <Label x:Name="FirstLabel" Content="1">
                        <Label.Style>
                            <Style>
                                <Style.Triggers>
                                    <MultiDataTrigger>
                                        <MultiDataTrigger.Conditions>
                                            <Condition Binding="{Binding ElementName=RadioButton1, Path=IsChecked}" Value="True" />
                                            <Condition Binding="{Binding ElementName=RadioButton3, Path=IsChecked}" Value="True" />
                                            <Condition Binding="{Binding ElementName=RadioButton5, Path=IsChecked}" Value="True" />
                                        </MultiDataTrigger.Conditions>
                                        <MultiDataTrigger.Setters>
                                            <Setter TargetName="FirstLabel" Property="Visibility" Value="Visible" />
                                        </MultiDataTrigger.Setters>
                                    </MultiDataTrigger>
                                </Style.Triggers>
                            </Style>
                        </Label.Style>
                    </Label>
                </StackPanel>
