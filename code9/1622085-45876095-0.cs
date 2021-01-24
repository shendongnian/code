    <telerik:radGridView.Resources>
      <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
          <ResourceDictionary>
            <Style TargetType="{x:Type telerik:RadTreeViewItem}">
              <Setter Property="IsExpanded" Value="{Binding Path=IsExpanded,Mode=TwoWay}"/>
            </Style>
          </ResourceDictionary>
        </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>
    </telerik:radGridView.Resources>
