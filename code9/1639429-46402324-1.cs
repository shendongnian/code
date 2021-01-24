    <Style x:Key="validationNotify" TargetType="validate:ControlWrapper">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="validate:ControlWrapper">
                    <StackPanel >
                        <ContentPresenter Content="{TemplateBinding Content}"/>
                        <ItemsControl DataContext="{TemplateBinding Property}" 
                                      ItemsSource="{Binding Errors, Source={TemplateBinding Property}}"  
                                      Style="{StaticResource validationNotifyMessage}" 
                                       >
                            <ItemsControl.ItemTemplate >
                                <DataTemplate>
                                    <StackPanel>
                                        <TextBlock Foreground="Red" Text="{Binding}"/>
                                    </StackPanel>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </StackPanel>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>                                                                        
