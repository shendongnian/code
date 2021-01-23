    Public Property AppThemes As New List(Of AppTheme)
    
    Public Property AccentColors As New List(Of ApplicationAccentColor)
	Public Property SelectedTheme As AppTheme
		Get
			Return ThemeManager.GetAppTheme(MySettings.Default.ApplicationThemeName)
		End Get
	    Set
			If ThemeManager.GetAppTheme(MySettings.Default.ApplicationThemeName) Is Value Then Exit Property
			MySettings.Default.ApplicationThemeName = value.Name
			MySettings.Default.Save()
			ThemeManager.ChangeAppStyle(Windows.Application.Current, ThemeManager.GetAccent(SelectedAccent.Name), ThemeManager.GetAppTheme(value.Name))
	    End Set
	End Property
	Public Property SelectedAccent As ApplicationAccentColor
		Get
			For Each acc As ApplicationAccentColor In From acc1 In AccentColors Where acc1.Name = MySettings.Default.ApplicationAccentName
				Return acc
			Next
			Return New ApplicationAccentColor()
		End Get
		Set
			If ThemeManager.GetAccent(MySettings.Default.ApplicationAccentName).Name is value.Name Then Exit Property
			MySettings.Default.ApplicationAccentName = value.Name
			MySettings.Default.Save()
			ThemeManager.ChangeAppStyle(Windows.Application.Current, ThemeManager.GetAccent(value.Name), ThemeManager.GetAppTheme(SelectedTheme.Name))
		End Set
	End Property
