    <Style 
        x:Key="ChartBarStyle" 
        TargetType="ContentControl" 
        >
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ContentControl">
                    <Expander 
                        x:Name="expander" 
                        Header="" 
                        VerticalAlignment="Top" 
                        Style="{DynamicResource ExpanderStyle1}"
                        >
                        <StackPanel Orientation="Vertical">
                            <ContentPresenter />
                            <WrapPanel HorizontalAlignment="Center">
                                <WrapPanel.Resources>
                                    <!-- Default style for all buttons in this WrapPanel -->
                                    <Style 
                                        TargetType="Button" 
                                        BasedOn="{StaticResource ButtonStyle1}" 
                                        />
                                </WrapPanel.Resources>
                                <Button Content="A" />
                                <Button Content="B" />
                                <Button Content="C" />
                                <Button Content="D" />
                                <Button Content="E" />
                                <Button Content="F" />
                            </WrapPanel>
                        </StackPanel>
                    </Expander>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
