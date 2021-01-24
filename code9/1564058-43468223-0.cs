    <UserControl x:Class="xxx.Views.ModuleFrameView">
        <Grid x:Name="ROOT">
           <TextBox Text="{Binding CurrentModule.Ch1SET}" IsEnabled="{Binding CurrentModule.IsEnbl_5}" IsReadOnly="True"                        
    TextAlignment="Center" ContextMenuService.ShowOnDisabled="True">
    <TextBox.ContextMenu >
         <ContextMenu>
             <MenuItem Header="Enable" cal:Message.Attach="cmEnable($source)" IsCheckable="True" IsChecked="{Binding Path=CurrentModule.IsEnbl_5, ElementName="ROOT"}"/>
         </ContextMenu>
    </TextBox.ContextMenu>
