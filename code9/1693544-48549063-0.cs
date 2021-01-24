    <ItemsControl xmlns:s="clr-namespace:System;assembly=mscorlib">
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
      <ItemsControl.ItemsSource>
        <x:Array Type="s:String">
          <s:String>ITEM_1</s:String>
          <s:String>ITEM_2</s:String>
          <s:String>ITEM_3</s:String>
          <s:String>ITEM_4</s:String>
          <s:String>ITEM_5</s:String>
        </x:Array>
      </ItemsControl.ItemsSource>
      <ItemsControl.ItemTemplate>
        <DataTemplate>
          <Expander Header="{Binding}">
            <TreeView ItemsSource="{Binding}" BorderThickness="0" Padding="0" />
          </Expander>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
