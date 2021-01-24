     <ListView 
                                Margin="0,50,0,0"  
                                VerticalAlignment="Stretch" 
                                HorizontalAlignment="Stretch" 
                                HorizontalContentAlignment="Stretch">
                                <ListView.Style>
                                    <Style TargetType="ListView">
                                        <Setter Property="MaxHeight" Value="150"/>
                                        <Setter Property="ItemsSource" Value="{Binding Users}"/>
                                            <Setter Property="View">
                                            <Setter.Value>
                                                <GridView AllowsColumnReorder="True" ColumnHeaderToolTip="Users">
                                                    <GridViewColumn Header="First Name" Width="Auto" DisplayMemberBinding="{Binding FirstName}"/>
                                                    <GridViewColumn Header="Last Name" Width="Auto" DisplayMemberBinding="{Binding LastName}"/>
                                                    <GridViewColumn Header="User Name" Width="Auto" DisplayMemberBinding="{Binding UserName}"/>
                                                    <GridViewColumn Header="Email" Width="Auto" DisplayMemberBinding="{Binding Email}"/>
                                                    <GridViewColumn Header="Employee Type" Width="Auto" DisplayMemberBinding="{Binding EmployeeType}"/>
                                                </GridView>
                                            </Setter.Value>
                                        </Setter>
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding ViewingProjects}" Value="True">
                                                <Setter Property="ItemsSource" Value="{Binding ProjectsCount}"/>
                                                    <Setter Property="View">
                                                    <Setter.Value>
                                                        <GridView AllowsColumnReorder="True" ColumnHeaderToolTip="Projects">
                                                            <GridViewColumn Header="Project Name" Width="Auto" DisplayMemberBinding="{Binding Project_Name}"/>
                                                            <GridViewColumn Header="Phase" Width="Auto" DisplayMemberBinding="{Binding Phase}"/>
                                                            <GridViewColumn Header="Hours Logged" Width="Auto" DisplayMemberBinding="{Binding Total_Hours_Worked}"/>
                                                            <GridViewColumn Header="Date Started" Width="Auto" DisplayMemberBinding="{Binding StartDate}"/>
                                                            <GridViewColumn Header="Proposed End Date" Width="Auto" DisplayMemberBinding="{Binding ProposedCompletionDate}"/>
                                                        </GridView>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </ListView.Style>
                            </ListView>
