    <Popup.IsOpen>
        <local:DelayedMultiBindingExtension Converter="{StaticResource PopupIsOpenConverter}" Delay="0:0:0.01">
            <Binding ElementName="PopupX" Path="IsMouseOver" Mode="OneWay" />
            <Binding ElementName="RecipientsTextBlock" Path="IsMouseOver" Mode="OneWay" />
        </local:DelayedMultiBindingExtension>
    </Popup.IsOpen>
