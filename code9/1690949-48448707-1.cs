    Dim VBrush As VisualBrush = TryCast(Me.Resources("Media"), VisualBrush)
    If VBrush IsNot Nothing Then
        Dim Media As MediaElement = TryCast(VBrush.Visual, MediaElement)
        If Media IsNot Nothing Then
            'Do your stuff here...
        End If
    End If
