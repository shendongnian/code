    <Window x:Class="PasswordBoxMVVM.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:PasswordBoxMVVM"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        xmlns:b="clr-namespace:System.Media;assembly=System"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <local:PasswordLengthToColorConverter x:Key="passwordLengthToColorConverter" />
    </Window.Resources>
    <Grid>
        <StackPanel VerticalAlignment="Center">
            <PasswordBox local:PasswordBoxMVVMAttachedProperties.EncryptedPassword="{Binding Path=Password, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                         IsEnabled="{Binding Path=IsPasswordFieldDisabled, Mode=TwoWay ,UpdateSourceTrigger=PropertyChanged}"
                         FontSize="20" Width="384" Height="34" PasswordChar="█" HorizontalAlignment="Center" FontFamily="Century Gothic" 
                         HorizontalContentAlignment="Left" VerticalContentAlignment="Center" TabIndex="2" Foreground="Red"
                         PasswordChanged="MyPasswordBox_PasswordChanged"
                         IsEnabledChanged="PasswordBox_IsEnabledChanged">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="PasswordChanged">
                        <i:InvokeCommandAction Command="{Binding Path=PasswordChangedCommand}" />
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                <PasswordBox.Style>
                    <Style TargetType="{x:Type PasswordBox}">
                        <Setter Property="Background" Value="#FFCCCCCC" />
                        <Setter Property="BorderThickness" Value="0,2,0,2" />
                        <Setter Property="BorderBrush" Value="Red" />
                        <Setter Property="ClipToBounds" Value="true"/>
                        <Setter Property="OverridesDefaultStyle" Value="true"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="PasswordBox">
                                    <Grid>
                                        <Border Background="{TemplateBinding Background}"
                                                BorderThickness="{TemplateBinding BorderThickness}"
                                                BorderBrush="{TemplateBinding Foreground}">
                                            <ScrollViewer x:Name="PART_ContentHost" Margin="0,-4,0,0"/>
                                        </Border>
                                        <TextBlock Name="TB" Text="Password" HorizontalAlignment="Left" Margin="140,0,0,0" VerticalAlignment="Center"  Opacity="0.3" Foreground="Gray">
                                        </TextBlock>
                                    </Grid>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsFocused" Value="true">
                                            <Setter TargetName="TB" Property="Text" Value="Password:" />
                                            <Trigger.EnterActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="100,0,34,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="2,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="1" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </Trigger.EnterActions>
                                            <Trigger.ExitActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="230,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="140,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="0.3" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </Trigger.ExitActions>
                                        </Trigger>
                                        <DataTrigger Binding="{Binding Path=IsPasswordFieldEmpty,Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Value="false">
                                            <Setter TargetName="TB" Property="Text" Value="Password:" />
                                            <DataTrigger.EnterActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="100,0,34,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="2,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="1" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </DataTrigger.EnterActions>
                                            <DataTrigger.ExitActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="230,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="140,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="0.3" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </DataTrigger.ExitActions>
                                        </DataTrigger>
                                        
                                        <MultiDataTrigger>
                                            <MultiDataTrigger.Conditions>
                                                <Condition Binding="{Binding Path=IsFocused, RelativeSource={RelativeSource Self}}" Value="false" />
                                                <Condition Binding="{Binding Path=IsPasswordFieldEmpty, UpdateSourceTrigger=PropertyChanged}" Value="true" />
                                            </MultiDataTrigger.Conditions>
                                            <Setter TargetName="TB" Property="Text" Value="Password" />
                                            <MultiDataTrigger.EnterActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="230,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="140,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="0.3" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <BackEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </MultiDataTrigger.EnterActions>
                                            <MultiDataTrigger.ExitActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ThicknessAnimation Storyboard.TargetProperty="Padding" To="100,0,34,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <ThicknessAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Margin" To="2,0,0,0" Duration="0:0:0.3">
                                                            <ThicknessAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </ThicknessAnimation.EasingFunction>
                                                        </ThicknessAnimation>
                                                        <DoubleAnimation Storyboard.TargetName="TB" Storyboard.TargetProperty="Opacity" To="1" Duration="0:0:0.3">
                                                            <DoubleAnimation.EasingFunction>
                                                                <SineEase EasingMode="EaseOut"/>
                                                            </DoubleAnimation.EasingFunction>
                                                        </DoubleAnimation>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </MultiDataTrigger.ExitActions>
                                        </MultiDataTrigger>
                                        <Trigger Property="IsEnabled" Value="false">
                                            <Setter TargetName="TB" Property="Text" Value="DISABLE"/>
                                            <Setter TargetName="TB" Property="Margin" Value="140,0,0,0"/>
                                            <Setter Property="Background" Value="#FFAAAAAA"/>
                                            <Setter Property="Foreground" Value="Gray"/>
                                            <Setter Property="BorderBrush" Value="#FF888888" />
                                            <Setter Property="BorderThickness" Value="0,3,0,3" />
                                        </Trigger>
                                        <Trigger Property="Tag" Value="ShowPW">
                                            <Setter Property="Visibility" Value="Hidden"/>
                                        </Trigger>
                                        <Trigger Property="Tag" Value="HidePW">
                                            <Setter Property="Visibility" Value="Visible"/>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                        <Style.Triggers>
                        </Style.Triggers>
                    </Style>
                </PasswordBox.Style>
                <PasswordBox.Triggers>
                    <EventTrigger RoutedEvent="PasswordBox.PasswordChanged">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimation Storyboard.TargetProperty="(PasswordBox.Foreground).(SolidColorBrush.Color)" 
                                                To="{Binding Path=Password.Length, UpdateSourceTrigger=PropertyChanged, 
                                                Converter={StaticResource passwordLengthToColorConverter}}" Duration="0:0:0.1">
                                </ColorAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="local:PasswordBoxAttachedEvent.HasBeenDisabled">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimation Storyboard.TargetProperty="(PasswordBox.Foreground).(SolidColorBrush.Color)" 
                                                To="Gray" Duration="0:0:0.1">
                                </ColorAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="local:PasswordBoxAttachedEvent.HasBeenEnabled">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimation Storyboard.TargetProperty="(PasswordBox.Foreground).(SolidColorBrush.Color)" 
                                                To="{Binding Path=Password.Length, UpdateSourceTrigger=PropertyChanged, 
                                                Converter={StaticResource passwordLengthToColorConverter}}" Duration="0:0:0.1">
                                </ColorAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </PasswordBox.Triggers>
            </PasswordBox>
            <Button Width="200" Height="50" Margin="0,50,0,0" Command="{Binding Path=ClickCommand}">Click me</Button>
        </StackPanel>
    </Grid>
