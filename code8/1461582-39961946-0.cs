        <ContentControl>
        <ContentControl.Resources>
            <DataTemplate x:Key="MyTmplKey">
                <TextBlock Text="Not null"/>
            </DataTemplate>
            <DataTemplate x:Key="DefaultTmplKey">
                <StackPanel>
                    <TextBlock Text="null"/>
                    <Button Content="Press" Click="Button_Click_1"/>
                </StackPanel>
            </DataTemplate>
        </ContentControl.Resources>
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Setter Property="ContentTemplate" Value="{StaticResource MyTmplKey}"/>
                <Style.Triggers>
                    <Trigger Property="DataContext" Value="{x:Null}">
                        <Setter Property="ContentTemplate" Value="{StaticResource DefaultTmplKey}"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
        </ContentControl>
