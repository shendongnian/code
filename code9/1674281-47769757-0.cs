    <ControlTemplate TargetType="{x:Type my:CustomControl}" x:Key="CustomTemplate">
        <Border BorderBrush="Green" BorderThickness="1" x:Name="outerBorder">
            <my:LabelControl Label="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=ViewModel.Label}">
                <TextBox HorizontalAlignment="Stretch" Padding="3 0 3 0" Foreground="{DynamicResource Control.Foreground}"
                         Tag="{Binding IsMouseOver, RelativeSource={RelativeSource AncestorType=my:CustomControl}}">
                    <TextBox.Resources>
                        <Style TargetType="{x:Type Border}">
                            <Setter Property="CornerRadius" Value="3"/>
                        </Style>
                    </TextBox.Resources>
                    <TextBox.Text>
                        <Binding Path="ViewModel.Value" UpdateSourceTrigger="PropertyChanged" RelativeSource="{RelativeSource TemplatedParent}" ValidatesOnDataErrors="True"/>
                    </TextBox.Text>
                    <Validation.ErrorTemplate>
                        <ControlTemplate>
                            <StackPanel x:Name="BorderBorder">
                                <Border BorderThickness="1" BorderBrush="Red" CornerRadius="3" HorizontalAlignment="Left" >
                                    <AdornedElementPlaceholder x:Name="textBox"/>
                                </Border>
                                <Border Background="LightGoldenrodYellow"  CornerRadius="3">
                                    <TextBlock Text="{Binding [0].ErrorContent}"/>
                                    <Border.Style>
                                        <Style>
                                            <Setter Property="Border.Visibility" Value="Collapsed"></Setter>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding AdornedElement.(TextBox.Tag), ElementName=textBox}" Value="True">
                                                    <Setter  Property="Border.Visibility" Value="Visible"></Setter>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </Border.Style>
                                </Border>
                            </StackPanel>
                        </ControlTemplate>
                    </Validation.ErrorTemplate>
                </TextBox>
            </my:LabelControl>
        </Border>
    </ControlTemplate>
