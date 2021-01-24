    <UserControl 
        x:Class="HH.HMI.ToolSuite.ResourceLib.Controls.ButtonSmall">
        <UserControl.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="../Styles/Buttons.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </UserControl.Resources>
        
        <Button 
            Content="{Binding ButtonImageSource, RelativeSource={RelativeSource AncestorType=UserControl}}"
            Style="{StaticResource StyleButtonBase}" 
            Width="{StaticResource DoubleWidthButtonSmall}" 
            Height="{StaticResource DoubleHeightControls}"
            />
    </UserControl>
