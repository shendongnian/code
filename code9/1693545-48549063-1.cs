    <ItemsControl xmlns:s="clr-namespace:System;assembly=mscorlib"
                  ItemsSource="{Binding Types}">
      <ItemsControl.Resources>
        <ControlTemplate x:Key="ExpanderButtonTemplate" TargetType="ToggleButton">
          <Border Background="Transparent" Padding="3,2">
            <ContentPresenter />
          </Border>
        </ControlTemplate>
        <Style TargetType="Expander">
          <Setter Property="Template">
            <Setter.Value>
              <ControlTemplate TargetType="Expander">
                <DockPanel LastChildFill="True">
                  <ToggleButton DockPanel.Dock="Top"
                                IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}"
                                Template="{StaticResource ExpanderButtonTemplate}">
                    <ContentPresenter ContentSource="Header" />
                  </ToggleButton>
                  <Border>
                    <ContentPresenter x:Name="contentSite" Visibility="Collapsed" />
                  </Border>
                </DockPanel>
                <ControlTemplate.Triggers>
                  <Trigger Property="IsExpanded" Value="True">
                    <Setter TargetName="contentSite" Property="Visibility" Value="Visible" />
                  </Trigger>
                </ControlTemplate.Triggers>
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style>
      </ItemsControl.Resources>
      <ItemsControl.ItemTemplate>
        <DataTemplate>
          <Expander Header="{Binding Name}">
            <TreeView ItemsSource="{Binding SubTypes}" BorderThickness="0" Padding="0">
              <TreeView.ItemTemplate>
                <HierarchicalDataTemplate DataType="{x:Type models:Type}"
                                          ItemsSource="{Binding SubTypes}">
                  <TextBlock Text="{Binding Name}"/>
                  <HierarchicalDataTemplate.ItemTemplate>
                    <DataTemplate DataType="{x:Type models:SubType}">
                      <TextBlock Text="{Binding Name}"/>
                    </DataTemplate>
                  </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
              </TreeView.ItemTemplate>
            </TreeView>
          </Expander>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
