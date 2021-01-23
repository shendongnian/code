    <Validation.ErrorTemplate>
        <ControlTemplate>
            <StackPanel xmlns:scm="clr-namespace:System.ComponentModel;assembly=WindowsBase">
                <StackPanel.Resources>
                    <CollectionViewSource x:Key="cvs" Source="{Binding}">
                        <CollectionViewSource.SortDescriptions>
                            <scm:SortDescription PropertyName="ErrorContent"  />
                        </CollectionViewSource.SortDescriptions>
                    </CollectionViewSource>
                </StackPanel.Resources>
                <AdornedElementPlaceholder x:Name="textBox" />
                <ItemsControl ItemsSource="{Binding Source={StaticResource cvs}}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding ErrorContent}">
                                <TextBlock.Style>
                                    <Style TargetType="{x:Type TextBlock}">
                                        <Setter Property="Foreground" Value="Red" />
                                        <Style.Triggers>
                                                        <DataTrigger Binding="{Binding ErrorContent.Severity}"
                                                             Value="{x:Static customEnums:Severity.WARNING}">
                                                            <Setter Property="Foreground"
                                                            Value="Orange" />
                                                        </DataTrigger>
                                                        <DataTrigger Binding="{Binding ErrorContent.Severity}"
                                                             Value="{x:Static customEnums:Severity.SUCCESS}">
                                                            <Setter Property="Foreground"
                                                            Value="DarkGreen" />
                                                            <Setter Property="FontWeight"
                                                            Value="Bold" />
                                                        </DataTrigger>
                                                    </Style.Triggers>
                                    </Style>
                                </TextBlock.Style>
                            </TextBlock>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </StackPanel>
        </ControlTemplate>
    </Validation.ErrorTemplate>
