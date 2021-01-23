    <ListView x:Name="editor" Background="White" Foreground="Black" SelectionMode="Single" BorderThickness="1" BorderBrush="DarkGray" Grid.Row="1">
        <ListView.View>
            <GridView AllowsColumnReorder="False">
                <GridViewColumn x:Name="LNRow" Header="" DisplayMemberBinding="{Binding LNRow}" Width="75" />
                <GridViewColumn x:Name="LRow" Header="" DisplayMemberBinding="{Binding LRow}" Width="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}, Converter={StaticResource WidthConverter}}" >
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <local:DiffTextBlock Value="{Binding LRow}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn x:Name="RNRow" Header="" DisplayMemberBinding="{Binding RNRow}" Width="75" />
                <GridViewColumn x:Name="RRow" Header="" DisplayMemberBinding="{Binding RRow}" Width="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}, Converter={StaticResource WidthConverter}}" />
            </GridView>
        </ListView.View>
        <ListView.Resources>
            <Style TargetType="GridViewColumnHeader">
                <Setter Property="Visibility" Value="Collapsed" />
            </Style>
            <Style TargetType="{x:Type ListViewItem}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Type}" Value="1">
                        <Setter Property="Background" Value="LightGray"/>
                        <Setter Property="Foreground" Value="Green"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Type}" Value="2">
                        <Setter Property="Background" Value="LightGray"/>
                        <Setter Property="Foreground" Value="Blue"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Type}" Value="3">
                        <Setter Property="Background" Value="LightGray"/>
                        <Setter Property="Foreground" Value="Red"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListView.Resources>
    </ListView>
