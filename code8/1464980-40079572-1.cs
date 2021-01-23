    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!--  MahApps.Metro resource dictionaries. Make sure that all file names are Case Sensitive!  -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.ContextMenu.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml" />
                <!--  Accent and AppTheme setting  -->
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Green.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        <!-- Apply MetroStyle for ContextMenu to ContextMenus in Application scope -->
        <Style TargetType="ContextMenu" BasedOn="{StaticResource MetroContextMenu}" />
    </Application.Resources>
