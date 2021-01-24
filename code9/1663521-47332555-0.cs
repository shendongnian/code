    <Grid>
            <ListBox ItemsSource="{Binding MyItems}">
                <ListBox.ItemTemplate>
                    <DataTemplate DataType="local:MyItem">
                        <TextBlock Text="{Binding Name}">
                              <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseEnter">
                        <i:InvokeCommandAction Command="{Binding MouseHoveredItemChangedCommand}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                        </TextBlock>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </Grid>
