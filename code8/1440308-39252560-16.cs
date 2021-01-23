    <ControlTemplate x:Key="ChartBarDefaultTemplate" TargetType="local:ChartBar">
        <!-- 
        Use Binding/RelativeSource TemplatedParent on IsExpanded so it updates both ways, 
        or remove that attribute/binding if you're not bothering with the IsExpanded DP.
        -->
        <Expander 
            x:Name="expander" 
            Header="" 
            VerticalAlignment="Top" 
            Style="{DynamicResource ExpanderStyle1}"
            IsExpanded="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}"
            >
            <StackPanel Orientation="Vertical">
                <ContentPresenter />
                <ContentControl 
                    Content="{TemplateBinding SecondaryContent}" 
                    />
            </StackPanel>
        </Expander>
    </ControlTemplate>
    
    <Style TargetType="local:ChartBar">
        <Setter 
            Property="Template" 
            Value="{StaticResource ChartBarDefaultTemplate}" 
            />
    </Style>
