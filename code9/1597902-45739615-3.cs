    Async Function XAMLtoPDF() As Task(Of Boolean)
        pdf = New C1PdfDocument(PaperKind.Letter)
        Dim lTB As New List(Of Object)
        Dim myRect As Rect = PageRectangleExt(pdf)
        Dim sfx As Double = myRect.Width  / myXAMLcontrol.ActualWidth
        Dim sfy As Double = myRect.Height  / myXAMLcontrol.ActualHeight
        FindTextBlocks(myXAMLcontrol, lTB)
        For x = 0 To lTB.Count - 1
            If TypeOf lTB(x) Is TextBlock Then
                Dim TB As TextBlock = lTB(x)
                Dim myfont As Font
                Select Case TB.FontStyle
                    Case FontStyle.Normal
                        If TB.FontWeight.Weight = FontWeights.Bold.Weight Then
                            myfont = New Font(TB.FontFamily.Source, TB.FontSize * sfy, PdfFontStyle.Bold)
                        Else
                            myfont = New Font(TB.FontFamily.Source, TB.FontSize * sfy, PdfFontStyle.Regular)
                        End If
                    Case Else  '(FontStyle.Oblique, FontStyle.Italic)      '
                        myfont = New Font(TB.FontFamily.Source, TB.FontSize * sfy, PdfFontStyle.Italic)
                End Select
                Dim ttv As GeneralTransform = TB.TransformToVisual(myXAMLcontrol)
                Dim ScreenCoords As Point = ttv.TransformPoint(New Point(0, 0))
                Dim myWidth As Double, myHeight As Double
                If TB.TextWrapping = TextWrapping.NoWrap Then
                    myWidth = pdf.MeasureString(TB.Text, myfont).Width
                    myHeight = pdf.MeasureString(TB.Text, myfont).Height
                Else
                    myWidth = TB.ActualWidth * sfx 
                    myHeight = pdf.MeasureString(TB.Text, myfont, myWidth).Height
                End If
                Dim rc As New Rect(ScreenCoords.X * sfx, ScreenCoords.Y * sfy, myWidth, myHeight)
                pdf.DrawString(TB.Text, myfont, CType(TB.Foreground, SolidColorBrush).Color, rc)
            ElseIf TypeOf lTB(x) Is Border Then
                Dim BDR As Border = lTB(x)
                Dim ttv As GeneralTransform = BDR.TransformToVisual(myXAMLcontrol)
                Dim ScreenCoords As Point = ttv.TransformPoint(New Point(0, 0))
                Dim pts() As Point = {
                    New Point(ScreenCoords.X * sfx, ScreenCoords.Y * sfy),
                    New Point(ScreenCoords.X * sfx + BDR.ActualWidth * sfx, ScreenCoords.Y * sfy),
                    New Point(ScreenCoords.X * sfx + BDR.ActualWidth * sfx, ScreenCoords.Y * sfy + BDR.ActualHeight * sfy),
                    New Point(ScreenCoords.X * sfx, ScreenCoords.Y * sfy + BDR.ActualHeight * sfy)}
                Dim MyPen As New Pen(CType(BDR.BorderBrush, SolidColorBrush).Color, 1)
                Dim Clr As Color = CType(BDR.BorderBrush, SolidColorBrush).Color
                If BDR.BorderThickness.Top Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Top * sfy), pts(0), pts(1))
                If BDR.BorderThickness.Right Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Right * sfx), pts(1), pts(2))
                If BDR.BorderThickness.Bottom Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Bottom * sfy), pts(2), pts(3))
                If BDR.BorderThickness.Left Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Left * sfx), pts(3), pts(0))
            End If
        Next
        Dim file As StorageFile = Await ThisApp.AppStorageFolder.CreateFileAsync("Temp.PDF", Windows.Storage.CreationCollisionOption.ReplaceExisting)
        Await pdf.SaveAsync(file)
        Return True
    End Function
    Private Sub FindTextBlocks(uiElement As Object, foundOnes As IList(Of Object))
        If TypeOf uiElement Is TextBlock Then
            Dim uiElementAsTextBlock = DirectCast(uiElement, TextBlock)
            If uiElementAsTextBlock.Visibility = Visibility.Visible Then
                foundOnes.Add(uiElementAsTextBlock)
            End If
        ElseIf TypeOf uiElement Is Panel Then
            Dim uiElementAsCollection = DirectCast(uiElement, Panel)
            If uiElementAsCollection.Visibility = Visibility.Visible Then
                For Each element In uiElementAsCollection.Children
                    FindTextBlocks(element, foundOnes)
                Next
            End If
        ElseIf TypeOf uiElement Is UserControl Then
            Dim uiElementAsUserControl = DirectCast(uiElement, UserControl)
            If uiElementAsUserControl.Visibility = Visibility.Visible Then
                FindTextBlocks(uiElementAsUserControl.Content, foundOnes)
            End If
        ElseIf TypeOf uiElement Is ContentControl Then
            Dim uiElementAsContentControl = DirectCast(uiElement, ContentControl)
            If uiElementAsContentControl.Visibility = Visibility.Visible Then
                FindTextBlocks(uiElementAsContentControl.Content, foundOnes)
            End If
        ElseIf TypeOf uiElement Is Border Then
            Dim uiElementAsBorder = DirectCast(uiElement, Border)
            If uiElementAsBorder.Visibility = Visibility.Visible Then
                foundOnes.Add(uiElementAsBorder)
                FindTextBlocks(uiElementAsBorder.Child, foundOnes)
            End If
        End If
    End Sub
