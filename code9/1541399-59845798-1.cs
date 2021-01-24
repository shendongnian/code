	Class Application
		Public Sub New()
			FrameworkElement.LanguageProperty.OverrideMetadata(
				GetType(FrameworkElement),
				New FrameworkPropertyMetadata(Markup.XmlLanguage.GetLanguage(Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)))
		End Sub
	End Class
