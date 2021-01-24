    //App or Page resources to set default properties 
    <ResourceDictionary>
        <Style TargetType="ActivityIndicator" x:Key="AIStyle">
            <Setter Property="IsEnabled" Value="{Binding Path=IsBusy}" />
            <Setter Property="IsRunning" Value="{Binding Path=IsBusy}" />
        </Style>
    </ResourceDictionary>
    //And use following to define control
    <OnPlatform x:TypeArguments="View">
        <On Platform="Android, iOS">
            <ActivityIndicator IsVisible="true" Style="{StaticResource AIStyle}" />
        </On>
        <On Platform="Windows">
            <ActivityIndicator IsVisible="{Binding Path=IsBusy}" Style="{StaticResource AIStyle}" />
        </On>
    </OnPlatform>
