    <ContentControl Focusable="False">
        <ContentControl.Content>
            <MultiBinding Converter="{StaticResource converter}">
                <Binding Path="X" />
                <Binding Path="Y" RelativeSource="..."/>
            </MultiBinding>
        </ContentControl.Content>
    </ContentControl>
