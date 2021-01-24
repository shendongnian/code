    <UserControl>
        <Grid>
            <TextBox>
            <Popup>
                <ListBox>
                    <ListBox.ItemContainerStyle>
                        <Style TargetType="ListBoxItem">
                            <Style.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="Background" Value="Blue"/>
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </ListBox.ItemContainerStyle>
                </ListBox>
            </Popup>
        </Grid>
    </UserControl>
