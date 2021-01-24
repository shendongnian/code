    <Style TargetType="{x:Type Button}" x:Key="StartButton_Style">
        <Setter Property="Background">
            <Setter.Value>
                <ImageBrush ImageSource="C:\Users\yosi1\OneDrive\מסמכים\Visual Studio 2017\Projects\Classic Story Launcher\Resources\Start_Button_Nornal.png"/>
            </Setter.Value>
        </Setter>
        <Setter Property="FontFamily" Value="Candara"/>
        <Setter Property="FontSize"   Value="40"/>
        <Setter Property="Foreground" Value="#FFA48B60"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border Background="{TemplateBinding Background}">
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="C:\Users\yosi1\OneDrive\מסמכים\Visual Studio 2017\Projects\Classic Story Launcher\Resources\Start_Button_Click.png"/>
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers>
    </Style>
