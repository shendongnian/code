    <UserControl.Resources>
        <!-- my dummy values -->
        <!-- 
        <SolidColorBrush x:Key="BackgroundBrush" Color="DarkGray" />
        <SolidColorBrush x:Key="TSBackgroundBrush" Color="Gray" />
        <SolidColorBrush x:Key="TSBarBrush" Color="LightGreen" />
        <SolidColorBrush x:Key="AccentColorBrush1" Color="Khaki" />
        -->
        <Style TargetType="Rectangle" x:Key="SliderRectangleStyle">
            <Setter Property="Stroke" Value="{DynamicResource BackgroundBrush}" />
            <Setter Property="Fill" Value="{DynamicResource TSBarBrush}" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="0">
                    <Setter Property="Grid.Column" Value="0" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="1">
                    <Setter Property="Grid.Column" Value="2" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="2">
                    <Setter Property="Grid.Column" Value="4" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
        <Style TargetType="Rectangle" x:Key="LeftFillRectangleStyle">
            <Setter Property="Stroke" Value="{DynamicResource BackgroundBrush}" />
            <Setter Property="Fill" Value="{DynamicResource AccentColorBrush1}" />
            <Setter Property="Margin" Value="2,2,0,2" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="0">
                    <Setter Property="Visibility" Value="Collapsed" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="1">
                    <Setter Property="Grid.ColumnSpan" Value="2" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="2">
                    <Setter Property="Grid.ColumnSpan" Value="4" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
        <Style x:Key="TextLabelStyle" TargetType="TextBlock">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="0">
                    <Setter Property="Text" Value="Aus" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="1">
                    <Setter Property="Text" Value="Client" />
                </DataTrigger>
                <DataTrigger Binding="{Binding Status, RelativeSource={RelativeSource AncestorType=UserControl}}" Value="2">
                    <Setter Property="Text" Value="Finance Dept." />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="10"/>
            <ColumnDefinition Width="10"/>
            <ColumnDefinition Width="10"/>
            <ColumnDefinition Width="10"/>
            <ColumnDefinition Width="10"/>
            <ColumnDefinition Width="auto"/>
        </Grid.ColumnDefinitions>
        <Rectangle 
            Margin="5,2,5,2" 
            Grid.Row="0" 
            Grid.Column="0" 
            Grid.ColumnSpan="5" 
            Fill="{DynamicResource BackgroundBrush}" 
            Stroke="{DynamicResource TSBackgroundBrush}"
            />
        <TextBlock 
            Grid.Row="0" 
            Grid.Column="5" 
            Style="{StaticResource TextLabelStyle}"
            Margin="4,0,4,0" 
            />
        <Rectangle Style="{StaticResource LeftFillRectangleStyle}" />
        <Rectangle Style="{StaticResource SliderRectangleStyle}" />
        <!-- Overlay the slider area with three equal click areas -->
        <Grid Grid.Column="0" Grid.ColumnSpan="5">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <Grid.Resources>
                <!-- 
                Because this style has no x:Key, it will apply to all Rectangles in this Grid 
                -->
                <Style TargetType="Rectangle" >
                    <!-- 
                    Uncomment these setters to make sure the clickable areas are where 
                    they should be.
                    -->
                    <!--
                    <Setter Property="Stroke" Value="Red" />
                    <Setter Property="StrokeThickness" Value="1" />
                    -->
                    <Setter Property="Fill" Value="Transparent" />
                    <EventSetter Event="PreviewMouseDown" Handler="StatusSelect_PreviewMouseDown" />
                </Style>
            </Grid.Resources>
            <Rectangle Grid.Column="0" />
            <Rectangle Grid.Column="1" />
            <Rectangle Grid.Column="2" />
        </Grid>
    </Grid>
