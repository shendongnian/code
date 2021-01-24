    <Button.IsEnabled>
        <MultiBinding Converter="{StaticResource AreAllTrueMultiValueConverter}">
            <Binding Path="EnableBtn" />
            <Binding Path="EnableMail" />
        </MultiBinding>
    </TextBox.IsEnabled>
