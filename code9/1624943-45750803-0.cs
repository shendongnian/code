        <StackPanel>
                <Expander x:Name="DataExpander" IsExpanded="{Binding expander_isExpanded}" >
                    <Expander.Header>
                        <TextBlock FontSize="18" FontFamily="Bold" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
       Text="{Binding expander_header_Text,FallbackValue=NoColor}"/>
                    </Expander.Header>
                    <Expander.Style>
                        <Style TargetType="Expander">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsMouseOver,ElementName=color0}" Value="True">
                                    <DataTrigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation  Storyboard.TargetProperty="(Expander.Background).Color" To="Red" Duration="0:0:0.3" BeginTime="0:0:1" />
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </DataTrigger.EnterActions>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding IsMouseOver,ElementName=color1}" Value="True">
                                    <DataTrigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation  Storyboard.TargetProperty="(Expander.Background).Color" To="Yellow" Duration="0:0:0.3" BeginTime="0:0:1" />
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </DataTrigger.EnterActions>
                                </DataTrigger>
    
                            </Style.Triggers>
                        </Style>
                    </Expander.Style>
                </Expander>
                <Border Margin="2,2,2,2" BorderBrush="Gray" CornerRadius="1,1,1,1" BorderThickness="1,1,1,1">
                    <Button Name="color0" Width="29" Background="Red"/>
                </Border>
                <Border Margin="2,2,2,2" BorderBrush="Gray" CornerRadius="1,1,1,1" BorderThickness="1,1,1,1">
                    <Button Name="color1" Width="29" Background="Yellow"/>
                </Border>
            </StackPanel>
