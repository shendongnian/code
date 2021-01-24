            <Style TargetType="{x:Type TextBox}">
                <Setter Property="Validation.ErrorTemplate">
                    <Setter.Value>
                        <ControlTemplate>
                            <StackPanel>
                                <AdornedElementPlaceholder>
                                    <Border BorderBrush="Red" BorderThickness="2"/>
                                </AdornedElementPlaceholder>
                                <ItemsControl ItemsSource="{Binding}">
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate>
                                            <Grid>
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="Auto" />
                                                    <ColumnDefinition Width="*" />
                                                </Grid.ColumnDefinitions>
                                                <TextBlock x:Name="ErrorText" Grid.Column="1" Text="{Binding ErrorContent}" Foreground="Red"/>
                                                <Image Grid.Column="0" Source="/Rotate.Pictures;component/Images/error.png"
                                                       Height="{Binding ElementName=ErrorText, Path=ActualHeight}"
                                                       Width="{Binding ElementName=ErrorText, Path=ActualHeight}"/>
                                            </Grid>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </StackPanel>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
