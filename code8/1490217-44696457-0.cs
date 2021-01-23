        <Grid>
            <StackPanel>
                <ListView x:Name="usergrid" Margin="100,50,100,0" HorizontalAlignment="Center" FontSize="20" ItemsSource="{Binding Path=user1}">
                    <ListView.View>
                        <GridView>
                            <GridViewColumn Header="UserId"       DisplayMemberBinding="{Binding UserId,Mode=TwoWay}" Width="100" ></GridViewColumn>
                            <GridViewColumn Header="First Name"   DisplayMemberBinding="{Binding FirstName,Mode=TwoWay}"  Width="150" />
                            <GridViewColumn Header="Last Name"    DisplayMemberBinding="{Binding LastName,Mode=TwoWay}" Width="150" />
                            <GridViewColumn Header="City"         DisplayMemberBinding="{Binding City,Mode=TwoWay}" Width="150" />
                            <GridViewColumn Header="State"        DisplayMemberBinding="{Binding State,Mode=TwoWay}" Width="150" />
                            <GridViewColumn Header="Country"      DisplayMemberBinding="{Binding Country,Mode=TwoWay}" Width="150" />
                        </GridView>
                    </ListView.View>
                </ListView>
            </StackPanel>
        </Grid>
