    ...
    <ItemsControl.ItemContainerStyle>
        <Style>
            ...
            <Setter Property="Canvas.Left">
                <Setter.Value>
                    <MultiBinding Converter="{StaticResource RelativePositionConverter}">
                        <MultiBinding.Bindings>
                            <Binding Path="Left" />
                            <Binding Path="ActualWidth" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type ItemsControl}}" />
                        </MultiBinding.Bindings>
                    </MultiBinding>
                </Setter.Value>
            </Setter>
            <Setter Property="Canvas.Top">
                <Setter.Value>
                    <MultiBinding Converter="{StaticResource RelativePositionConverter}">
                        <MultiBinding.Bindings>
                            <Binding Path="Top" />
                            <Binding Path="ActualHeight" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type ItemsControl}}" />
                        </MultiBinding.Bindings>
                    </MultiBinding>
                </Setter.Value>
            </Setter>
            ...
        </Style>
    </ItemsControl.ItemContainerStyle>
    ...
