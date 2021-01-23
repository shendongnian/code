    <GridViewColumn CellTemplate="{StaticResource IssueTemplate}">
        <GridViewColumnHeader HorizontalAlignment="Center">
            <StackPanel HorizontalAlignment="Center">
                <TextBlock Text="Issue" HorizontalAlignment="Center"/>
                    <Viewbox>
                        <Button Content="Check/Uncheck All" FontSize="6" Margin="5 0 5 0" Command="{Binding CheckClick}"/>
                    </Viewbox>
            </StackPanel>
        </GridViewColumnHeader>
    </GridViewColumn>
