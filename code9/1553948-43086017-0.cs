    <ListView ItemsSource="{Binding UserProfileData}">
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Name}">
                        <GridViewColumnHeader Content="User ID">
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="Click">
                                    <ei:CallMethodAction TargetObject="{Binding}" MethodName="OnClick"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </GridViewColumnHeader>
                    </GridViewColumn>
                    <GridViewColumn DisplayMemberBinding="{Binding LastUsed}">
                        <GridViewColumnHeader Content="Last Loaded">
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="Click">
                                    <ei:CallMethodAction TargetObject="{Binding}" MethodName="OnClick"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </GridViewColumnHeader>
                    </GridViewColumn>
                    <GridViewColumn DisplayMemberBinding="{Binding IsLoaded}">
                        <GridViewColumnHeader Content="Logged In">
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="Click">
                                    <ei:CallMethodAction TargetObject="{Binding}" MethodName="OnClick"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </GridViewColumnHeader>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
