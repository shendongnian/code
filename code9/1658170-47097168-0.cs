                <MenuItem x:Name="RecentScripts" Header="Recent _Files" cal:Message.Attach="OpenRecentScript($orignalsourcecontext)">
                    <MenuItem.Icon>
                        <Image Source="{StaticResource IconOpen}"/>
                    </MenuItem.Icon>
                    <MenuItem.ItemTemplate>
                        <DataTemplate>
                            <Label Content="{Binding Caption}"/>
                        </DataTemplate>
                    </MenuItem.ItemTemplate>
                </MenuItem> 
