    <ListView Name="List"
        ItemsSource="{Binding MusicList, UpdateSourceTrigger=PropertyChanged}"  
        SelectedIndex="{Binding SelectedIndex}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name, UpdateSourceTrigger=PropertyChanged}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                           <Style.Triggers>
                               <DataTrigger Binding="{Binding IsPlaying}" Value="True">
                                   <Setter Property="Foreground" Value="Red"/>
                               </DataTrigger>
                           </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
