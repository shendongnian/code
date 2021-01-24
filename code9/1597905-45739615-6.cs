    Async Function XAMLtoPDF(myXAMLcontrol As Control) As Task(Of Boolean)
        Dim pdf As C1PdfDocument
        pdf = New C1PdfDocument(PaperKind.Letter)
        Dim lTB As New List(Of Object)
        pdf.PageSize = New Size(myXAMLcontrol.ActualWidth, myXAMLcontrol.ActualHeight)
        FindTextBlocks(myXAMLcontrol, lTB)
        For x = 0 To lTB.Count - 1
            If TypeOf lTB(x) Is TextBlock Then
                Dim TB As TextBlock = lTB(x)
                Dim obj As FrameworkElement = TB
                Dim angle As Double = 0
                Do While obj IsNot Nothing
                    Dim renderxform As Transform = obj.RenderTransform
                    If TypeOf renderxform Is TransformGroup Then
                        Dim tg As TransformGroup = CType(renderxform, TransformGroup)
                        For Each t As Transform In tg.Children
                            If TypeOf t Is RotateTransform Then
                                angle -= CType(t, RotateTransform).Angle
                            End If
                        Next
                    ElseIf TypeOf renderxform Is RotateTransform Then
                        angle -= CType(renderxform, RotateTransform).Angle
                    End If
                    obj = obj.Parent
                Loop
                Dim myfont As Font
                Select Case TB.FontStyle
                    Case FontStyle.Normal
                        If TB.FontWeight.Weight = FontWeights.Bold.Weight Then
                            myfont = New Font(TB.FontFamily.Source, TB.FontSize, PdfFontStyle.Bold)
                        Else
                            myfont = New Font(TB.FontFamily.Source, TB.FontSize, PdfFontStyle.Regular)
                        End If
                    Case Else  'FontStyle.Oblique, FontStyle.Italic             '
                        myfont = New Font(TB.FontFamily.Source, TB.FontSize, PdfFontStyle.Italic)
                End Select
                Dim ttv As GeneralTransform = TB.TransformToVisual(myXAMLcontrol)
                Dim ScreenCoords As Point = ttv.TransformPoint(New Point(0, 0))
                Dim myWidth As Double, myHeight As Double
                If TB.TextWrapping = TextWrapping.NoWrap Then
                    myWidth = pdf.MeasureString(TB.Text, myfont).Width
                    myHeight = pdf.MeasureString(TB.Text, myfont).Height
                Else
                    myWidth = TB.ActualWidth + 10       'Admittedly, 10 is a kluge factor to make wrapping match'
                    myHeight = pdf.MeasureString(TB.Text, myfont, myWidth).Height
                End If
                Dim rc As New Rect(ScreenCoords.X, ScreenCoords.Y, myWidth, myHeight)
                If angle Then
                    Dim fmt As New StringFormat()
                    fmt.Angle = angle
                    pdf.DrawString(TB.Text, myfont, CType(TB.Foreground, SolidColorBrush).Color, rc, fmt)
                Else
                    pdf.DrawString(TB.Text, myfont, CType(TB.Foreground, SolidColorBrush).Color, rc)
                End If
            ElseIf TypeOf lTB(x) Is Border Then
                Dim BDR As Border = lTB(x)
                Dim ttv As GeneralTransform = BDR.TransformToVisual(myXAMLcontrol)
                Dim ScreenCoords As Point = ttv.TransformPoint(New Point(0, 0))
                Dim pts() As Point = {
                    New Point(ScreenCoords.X, ScreenCoords.Y),
                    New Point(ScreenCoords.X + BDR.ActualWidth, ScreenCoords.Y),
                    New Point(ScreenCoords.X + BDR.ActualWidth, ScreenCoords.Y + BDR.ActualHeight),
                    New Point(ScreenCoords.X, ScreenCoords.Y + BDR.ActualHeight)}
                Dim Clr As Color = CType(BDR.BorderBrush, SolidColorBrush).Color
                If BDR.BorderThickness.Top Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Top), pts(0), pts(1))
                If BDR.BorderThickness.Right Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Right), pts(1), pts(2))
                If BDR.BorderThickness.Bottom Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Bottom), pts(2), pts(3))
                If BDR.BorderThickness.Left Then pdf.DrawLine(New Pen(Clr, BDR.BorderThickness.Left), pts(3), pts(0))
            ElseIf TypeOf lTB(x) Is Rectangle Then
                Dim Rect As Rectangle = lTB(x)
                Dim ttv As GeneralTransform = Rect.TransformToVisual(myXAMLcontrol)
                Dim ScreenCoords As Point = ttv.TransformPoint(New Point(0, 0))
                Dim pts() As Point = {
                    New Point(ScreenCoords.X + Rect.Margin.Left, ScreenCoords.Y + Rect.Margin.Top),
                    New Point(ScreenCoords.X + Rect.ActualWidth - Rect.Margin.Right, ScreenCoords.Y + Rect.Margin.Top),
                    New Point(ScreenCoords.X + Rect.ActualWidth - Rect.Margin.Right, ScreenCoords.Y + Rect.ActualHeight - Rect.Margin.Bottom),
                    New Point(ScreenCoords.X + Rect.Margin.Left, ScreenCoords.Y + Rect.ActualHeight - Rect.Margin.Bottom)}
                Dim MyPen1 As New Pen(CType(Rect.Stroke, SolidColorBrush).Color, Rect.StrokeThickness)
                MyPen1.DashStyle = DashStyle.Custom
                MyPen1.DashPattern = Rect.StrokeDashArray.ToArray
                Dim MyPen2 As New Pen(CType(Rect.Stroke, SolidColorBrush).Color, Rect.StrokeThickness)
                MyPen2.DashStyle = DashStyle.Custom
                MyPen2.DashPattern = Rect.StrokeDashArray.ToArray
                pdf.DrawLine(MyPen2, pts(0), pts(1))
                pdf.DrawLine(MyPen1, pts(1), pts(2))
                pdf.DrawLine(MyPen2, pts(2), pts(3))
                pdf.DrawLine(MyPen1, pts(3), pts(0))
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
        ElseIf TypeOf uiElement Is Rectangle Then
            Dim uiElementAsRectangle = DirectCast(uiElement, Rectangle)
            foundOnes.Add(uiElementAsRectangle)
        End If
    End Sub
