      <ComboBox 
         x:Name="cboSourceMySql" 
           Grid.Column="1" Margin="5,0,5,0" 
           ItemsSource="{Binding OdbcDataSources, Mode=TwoWay}" 
           Grid.Row="1" >
                <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Server}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ComboBox.ItemContainerStyle>
                <Style TargetType="{x:Type ComboBoxItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                                <Border
                                    x:Name="Bd"
                                    Background="{TemplateBinding Background}"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                    <StackPanel Orientation="Vertical">
                                        <Label Content="{Binding Server}" />
                                        <Label Content="{Binding Driver}" />
                                    </StackPanel>
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsHighlighted" Value="True">
                                        <Setter TargetName="Bd" Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}" />
                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}" />
                                    </Trigger>
                                    <Trigger Property="IsEnabled" Value="False">
                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ComboBox.ItemContainerStyle>
        </ComboBox>
