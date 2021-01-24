    <CheckBox x:Name="RowCheckBox" IsHitTestVisible="False">
        <CheckBox.IsChecked>
            <MultiBinding Converter="{StaticResource MultiValueConverter}" Mode="OneWay">
                <Binding Path="IsSelected" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type DataGridRow}}" />
                <Binding Path="IsChecked" RelativeSource="{RelativeSource Self}" />
                <Binding Mode="OneWay" RelativeSource="{RelativeSource Self}" />
            </MultiBinding>
        </CheckBox.IsChecked>
    </CheckBox>
