    <telerik:radGridView.Resources>
      <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/OtherAssembly,component/existingStyles.xaml />
        </ResourceDictionary.MergedDictionaries>
        <Style BasedOn="{StaticResource xKeyOfStyleToExtendFromExistingStyles}" TargetType="{x:Type telerik:RadTreeViewItem}">
            <Setter Property="IsExpanded" Value="{Binding Path=IsExpanded, Mode=TwoWay}"/>
        </Style>
      </ResourceDictionary>
    </telerik:radGridView.Resources>
