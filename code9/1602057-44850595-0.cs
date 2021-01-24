    <MyControl.Resources>       
        <BooleanToVisibilityConverter x:Key="BoolToVis"/>
    </MyControl.Resources>
    <!--Sets a context menu for each ListBoxItem in the current ListBox-->
    <Style TargetType="{x:Type ListViewItem}">
      <Setter Property="ContextMenu">
        <Setter.Value>
          <ContextMenu IsEnabled="{Binding HasTrackingNumber}" Visibility="{Binding HasTrackingNumber, Converter={StaticResource BoolToVis}">
            <MenuItem Header="Track Item" Click="MenuItem_Click"></MenuItem>
            <MenuItem Header="Copy to Clipboard" Click="MenuItem_CopyToClipboard"></MenuItem>
          </ContextMenu>
        </Setter.Value>
      </Setter>  
    </Style>
