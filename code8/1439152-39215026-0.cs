    <SolidColorBrush x:Key="TextBox.Static.Border" Color="#FFABAdB3"/>
    <SolidColorBrush x:Key="TextBox.MouseOver.Border" Color="#FF7EB4EA"/>
    <SolidColorBrush x:Key="TextBox.Focus.Border" Color="#FF569DE5"/>
    <Style x:Key="CWWatermarkTextBoxStyle" TargetType="{x:Type TextBox}" 
           xmlns:sys="clr-namespace:System;assembly=mscorlib">
       <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}"/>
       <Setter Property="BorderBrush" Value="{StaticResource TextBox.Static.Border}"/>
       <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
       <Setter Property="BorderThickness" Value="1"/>
       <Setter Property="KeyboardNavigation.TabNavigation" Value="None"/>
       <Setter Property="HorizontalContentAlignment" Value="Left"/>
       <Setter Property="FocusVisualStyle" Value="{x:Null}"/>
       <Setter Property="AllowDrop" Value="true"/>
       <Setter Property="ScrollViewer.PanningMode" Value="VerticalFirst"/>
       <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
       <Setter Property="Template">
          <Setter.Value>
             <ControlTemplate TargetType="{x:Type TextBox}">
                <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                   <Grid>
                      <ScrollViewer x:Name="PART_ContentHost" Focusable="false" HorizontalScrollBarVisibility="Hidden" VerticalScrollBarVisibility="Hidden"/>
                      <TextBlock x:Name="GenericWatermark"
                                 Text="{Binding Tag, RelativeSource={RelativeSource TemplatedParent}}"
                                 Foreground="Red" Margin="5,0" Visibility="Collapsed"/>
                   </Grid>
                </Border>
             <ControlTemplate.Triggers>
                <Trigger Property="Text" Value="{x:Static sys:String.Empty}">
                   <Setter Property="Visibility" TargetName="GenericWatermark" Value="Visible" />
                   <Setter Property="Background" Value="Yellow" />
                </Trigger>
                <Trigger Property="IsEnabled" Value="false">
                   <Setter Property="Opacity" TargetName="border" Value="0.56"/>
                </Trigger>
                <Trigger Property="IsMouseOver" Value="true">
                   <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.MouseOver.Border}"/>
                </Trigger>
                <Trigger Property="IsKeyboardFocused" Value="true">
                   <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.Focus.Border}"/>
                   <Setter Property="Visibility" TargetName="GenericWatermark" Value="Collapsed"/>
                </Trigger>
             </ControlTemplate.Triggers>
          </ControlTemplate>
       </Setter.Value>
       </Setter>
       <Style.Triggers>
          <MultiTrigger>
             <MultiTrigger.Conditions>
                <Condition Property="IsInactiveSelectionHighlightEnabled" Value="true"/>
                <Condition Property="IsSelectionActive" Value="false"/>
             </MultiTrigger.Conditions>
             <Setter Property="SelectionBrush" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
          </MultiTrigger>
       </Style.Triggers>
    </Style>
