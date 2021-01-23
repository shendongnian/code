    <local:MyListView ItemsSource="{Binding Source={StaticResource items}}">
        <local:MyListView.ItemContainerStyle>
            <Style TargetType="{x:Type local:DesignerItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type local:DesignerItem}">
                            <ContentPresenter x:Name="MyContent" ContentSource="Content"/>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                    <Setter TargetName="MyContent" Property="ContentTemplate" Value="{Binding ContentEditTemplate,RelativeSource={RelativeSource TemplatedParent}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </local:MyListView.ItemContainerStyle>
        <local:MyListView.ItemTemplate>
            <DataTemplate>
                <Border Background="Red" Margin="5" Padding="5">
                    <TextBlock Text="Hello World"/>
                </Border>
            </DataTemplate>
        </local:MyListView.ItemTemplate>
        <local:MyListView.ItemEditTemplate>
            <DataTemplate>
                <Border Background="Green" Margin="5" Padding="5">
                    <TextBlock Text="Hello World"/>
                </Border>
            </DataTemplate>
        </local:MyListView.ItemEditTemplate>
    </local:MyListView>
