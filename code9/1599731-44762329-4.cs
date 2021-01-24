    <MenuItem Header="Corriger" StaysOpenOnClick="True">
        <MenuItem>
            <MenuItem.Header>
                <StackPanel Orientation="Horizontal" Margin="2,0,0,0">
                    <Label Content="Dispo" />
                    <TextBox Text="" VerticalContentAlignment="Center" Width="60" />
                    <Label Content="%" />
                    <CheckBox Margin="0,5,0,0" Content="dont les 100%" />
                </StackPanel>
            </MenuItem.Header>
        </MenuItem>
        <MenuItem>
            <MenuItem.Header>
                <StackPanel Orientation="Horizontal" Margin="0,5,0,0">
                    <Label Content="Commentaire"/>
                    <TextBox Height="25" Width="135" VerticalContentAlignment="Center" Text="" />
                </StackPanel>
            </MenuItem.Header>
        </MenuItem>
        <Separator />
        <MenuItem>
            <MenuItem.Header>
                <Button Content="OK" Width="80" Height="20" />
            </MenuItem.Header>
        </MenuItem>
    </MenuItem>
