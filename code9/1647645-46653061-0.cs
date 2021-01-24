    <ListView Margin="10,36,520,10" ScrollViewer.HorizontalScrollBarVisibility="Hidden" BorderBrush="Black" Padding="-1, -1, 1, 0" Background="Transparent" BorderThickness="1.000001" Name="lvUsers"  >
        <ListView.Resources>
            <ContextMenu x:Key="ListViewItemContextMenu">
                <MenuItem Name="cmndOP" Header="OP User" Click="cmndOP_Click" />
                <MenuItem Header="Kick User"/>
                <MenuItem Header="Ban User"/>
                <MenuItem Header="Send Command"/>
            </ContextMenu>
        </ListView.Resources>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="ContextMenu" Value="{StaticResource ListViewItemContextMenu}" />
