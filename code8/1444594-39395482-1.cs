    <Grid>
        <ComboBox SelectedIndex="1" Foreground="Transparent">
            <ComboBox.Resources>
                <Style TargetType="{x:Type ComboBoxItem}">
                    <!-- Make sure ComboBoxItems don't have transparent text -->
                    <Setter Property="Foreground" Value="{StaticResource {x:Static SystemColors.ControlTextBrushKey}}" />
                </Style>
            </ComboBox.Resources>
            <ComboBoxItem>Test 1</ComboBoxItem>
            <ComboBoxItem>Test 2</ComboBoxItem>
            <ComboBoxItem>Test 3</ComboBoxItem>
        </ComboBox>
    
        <TextBlock Text="Select Countries" Margin="4,3" IsHitTestVisible="False" />
    </Grid>
