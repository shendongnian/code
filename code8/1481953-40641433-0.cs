    <ListView Background="Transparent" IsEnabled="False">
        <ListView.Template>
            <ControlTemplate TargetType="ListView">
                <Border Name="Border"                        
                        BorderThickness="1">
                    <ScrollViewer Style="{DynamicResource {x:Static GridView.GridViewScrollViewerStyleKey}}">
                        <ItemsPresenter />
                    </ScrollViewer>
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsGrouping" Value="true">
                        <Setter Property="ScrollViewer.CanContentScroll" Value="false" />
                    </Trigger>
                    <Trigger Property="IsEnabled" Value="false">
                        <Setter TargetName="Border" Property="Background" Value="Transparent" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </ListView.Template>
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding FirstName}" Header="First Name" />
                <GridViewColumn DisplayMemberBinding="{Binding LastName}" Header="Last Name" />
                <GridViewColumn DisplayMemberBinding="{Binding EmailAddress}" Header="Email" />
            </GridView>
        </ListView.View>
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
