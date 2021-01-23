    <Style x:Key="TabItemStyle1" TargetType="{x:Type TabItem}">
        <Setter Property="HeaderTemplate">
            <Setter.Value>
                <DataTemplate>
                    <Border x:Name="grid" Background="{StaticResource TabItem.Selected.Background}">
                        <ContentPresenter>
                            <ContentPresenter.Content>
                                <TextBlock Margin="4" FontSize="15" Text="{TemplateBinding Content}"/>
                            </ContentPresenter.Content>
                        </ContentPresenter>
                    </Border>
                    <DataTemplate.Triggers>
                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type TabItem}},Path=IsSelected}" Value="True">
                            <Setter TargetName="grid" Property="Background" Value="{StaticResource TabItem.Selected.Background}"/>
                        </DataTrigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </Setter.Value>
        </Setter>
