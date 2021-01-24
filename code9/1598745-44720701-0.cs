    <VisualStateManager.VisualStateGroups>
                <VisualStateGroup>
                    <VisualState x:Name="wideView">
                        <VisualState.StateTriggers>
                            <AdaptiveTrigger MinWindowWidth="720" />
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                          
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="narrowView">
                        <VisualState.Setters>
                            <Setter Target="Grid1.(Grid.RowSpan)" Value="1"></Setter>
                            <Setter Target="Grid1.(Grid.ColumnSpan)" Value="2"></Setter>
    
                            <Setter Target="Grid2.(Grid.RowSpan)" Value="1"></Setter>
                            <Setter Target="Grid2.(Grid.Row)" Value="1"></Setter>
                            <Setter Target="Grid2.(Grid.ColumnSpan)" Value="2"></Setter>
                            <Setter Target="Grid2.(Grid.Column)" Value="0"></Setter>
                        </VisualState.Setters>
                        <VisualState.StateTriggers>
                            <AdaptiveTrigger MinWindowWidth="0" />
                        </VisualState.StateTriggers>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
    
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="177*"/>
                    <RowDefinition Height="143*"/>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition></ColumnDefinition>
                    <ColumnDefinition></ColumnDefinition>
                </Grid.ColumnDefinitions>
                <Grid x:Name="Grid1" Margin="10,10,10,10" Background="Black" Grid.RowSpan="2" ></Grid>
                <Grid x:Name="Grid2" Grid.Column="1" Grid.Row="0" Grid.RowSpan="2" Margin="10,10,10,10" Background="Black" ></Grid>
            </Grid>
