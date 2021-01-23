    <ListView Name="List"
        ItemsSource="{Binding MusicList, UpdateSourceTrigger=PropertyChanged}"  
        SelectedIndex="{Binding SelectedIndex}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="IsSelected" Value="{Binding Path=IsSelected, Mode=TwoWay}"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name, UpdateSourceTrigger=PropertyChanged}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                           <Style.Triggers>
                               <DataTrigger Binding="{Binding IsPlaying}" Value="True">
                                   <Setter Property="Foreground" Value="Red"/>
                               </DataTrigger>
                               <DataTrigger Binding="{Binding IsSelected}" Value="True">
                                   <Setter Property="Background" Value="Blue"/>
                               </DataTrigger>
                           </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
