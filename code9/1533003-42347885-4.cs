    <ContentControl
        Content="{Binding Model}"
        >
        <ContentControl.ContentTemplate>
            <MultiBinding 
                Converter="{StaticResource ContentTemplateConverter}"
                >
                <Binding Path="Model" />
                <!-- The ContentControl itself will be used for FindResource() -->
                <Binding RelativeSource="{RelativeSource Self}" />
                <!-- 
                The converter doesn't use this, but including it will induce 
                the binding to update the target when Foo changes.
                -->
                <Binding Path="Model.Foo" />
            </MultiBinding>
        </ContentControl.ContentTemplate>
    </ContentControl>
