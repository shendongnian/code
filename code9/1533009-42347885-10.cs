    <ContentControl
        Content="{Binding Model}"
        >
        <ContentControl.ContentTemplate>
            <MultiBinding 
                Converter="{StaticResource ContentTemplateConverter}"
                >
                <!-- 
                We must bind to Model.Foo so the binding updates when that changes, 
                but we could also bind to Model as well if the converter wants to 
                look at other properties besides Foo. 
                -->
                <Binding Path="Model.Foo" />
                <!-- The ContentControl itself will be used for FindResource() -->
                <Binding RelativeSource="{RelativeSource Self}" />
            </MultiBinding>
        </ContentControl.ContentTemplate>
    </ContentControl>
