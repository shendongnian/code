    <Grid x:Name="grid1">
        <Grid.Resources>
            <local:WeekComparer x:Key="sameWeekComparer"/>
        </Grid.Resources>
        <ListView x:Name="lv1" ItemsSource="{Binding}">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Style.Triggers>
                        <DataTrigger Value="False">
                            <DataTrigger.Binding>
                                <MultiBinding Converter="{StaticResource sameWeekComparer}">
                                    <Binding Path="MyDate" RelativeSource="{RelativeSource PreviousData}"/>
                                    <Binding Path="MyDate"/>
                                </MultiBinding>
                            </DataTrigger.Binding>
                            <Setter Property="BorderBrush" Value="Red"/>
                            <Setter Property="BorderThickness" Value="0 4 0 0"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.View>
                <GridView x:Name="gv1">
                    <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="Name"/>
                    <GridViewColumn DisplayMemberBinding="{Binding MyDate}" Header="MyDate"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
