    <ContentControl Content="{Binding MyObject.MyChosenEnum}">
        <ContentControl.Resources>
            <DataTemplate x:Key="Enum1">
                <Grid />
            </DataTemplate>
            <DataTemplate x:Key="Enum2">
                <Grid />
            </DataTemplate>
        </ContentControl.Resources>
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding MyObject.MyChosenEnum}"
                                 Value="{x:Static myenumsNameSpace:Enums+MyEnumsForDropDown.Enum1}">
                        <Setter Property="ContentTemplate" Value="{StaticResource Enum1}" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding MyObject.MyChosenEnum}"
                                 Value="{x:Static myenumsNameSpace:Enums+MyEnumsForDropDown.Enum2}">
                        <Setter Property="ContentTemplate" Value="{StaticResource Enum2}" />
                    </DataTrigger>
                    <!-- and so on for each enum value -->
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
