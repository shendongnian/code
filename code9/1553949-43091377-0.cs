    <ListView x:Name="test" ItemsSource="{Binding UserProfileData}">
        <ListView.Resources>
            <Style TargetType="GridViewColumnHeader">
                <Setter Property="Command" Value="{Binding YourCommandProperty}" />
                <Setter Property="CommandParameter" Value="{Binding Content, RelativeSource={RelativeSource Self}}" />
            </Style>
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="User ID"/>
                <GridViewColumn DisplayMemberBinding="{Binding LastUsed}" Header="Last Loaded"/>
                <GridViewColumn DisplayMemberBinding="{Binding IsLoaded}" Header="Logged In"/>
            </GridView>
        </ListView.View>
    </ListView>
