     <Application.Resources>
        <ResourceDictionary>
            <!--Estilo Validação-->
        <Style TargetType="TextBox">
            <Setter Property="Validation.ErrorTemplate">
                <Setter.Value>
                    <ControlTemplate>
                        <StackPanel>
                            <AdornedElementPlaceholder x:Name="placeholder"/>
                            <TextBlock FontSize="12" Foreground="Red"  
                                       Text="{Binding ElementName=placeholder,Path=AdornedElement.(Validation.Errors)[0].ErrorContent}"/>
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="Validation.HasError" Value="True">
                    <Setter Property="Background" Value="Red"/>
                    <Setter Property="ToolTip" Value="{Binding RelativeSource={RelativeSource Self}, 
                      Path=(Validation.Errors)[0].ErrorContent}"/>
                </Trigger>
            </Style.Triggers>
        </Style>
     
        <!--FIM Estilo Validação-->
       
            <ResourceDictionary.MergedDictionaries>
                <!-- MahApps.Metro resource dictionaries. Make sure that all file names are Case Sensitive! -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml" />
                <!-- Accent and AppTheme setting -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
