    Sub Test()
    Dim newRng As Range
     Set newRng = Application.Union(Range("A1:b18"), Range("e4:e5"))
     newRng.Value = 10
    End Sub
