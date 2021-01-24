    Imports System.Drawing
    'Imports System.Runtime.InteropServices
    Imports System.Windows.Forms
    Imports CrystalDecisions.CrystalReports.Engine
    Imports CrystalDecisions.Windows.Forms
    
    Public Class CrystalReportViewerMouseWheelZoom
        Implements IMessageFilter
    
        Private WithEvents _viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Private _viewerForm As Form = Nothing
        Private _ZoomLevel As Integer
        Public Sub New(viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer)
            Me._viewer = viewer
            Application.AddMessageFilter(Me)
        End Sub
    
        Private Sub _viewer_Disposed(sender As Object, e As EventArgs) Handles _viewer.Disposed
            Application.RemoveMessageFilter(Me)
            _viewer = Nothing
        End Sub
    
        Private Sub _viewer_ViewZoom(source As Object, e As ZoomEventArgs) Handles _viewer.ViewZoom
            _ZoomLevel = e.NewZoomFactor
        End Sub
    
        '<DllImport("user32.dll")>
        'Private Shared Function WindowFromPoint(ByVal p As Point) As IntPtr
        'End Function
    
        Private Const ZOOM_LEVEL_DELTA_PERC As Double = 5D
        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            If (m.Msg <> &H20A) Then Return False
    
            If Not My.Computer.Keyboard.CtrlKeyDown Then Return False
    
            Dim mouseAbsolutePosition = New Point(m.LParam.ToInt32())
            Dim mouseRelativePosition = _viewer.PointToClient(mouseAbsolutePosition)
    
    
            'DOEW NOT WORK, Control.FromHandle return always null
            'Dim hControlUnderMouse As IntPtr = WindowFromPoint(mouseAbsolutePosition)
            'Dim controlUnderMouse = Control.FromHandle(hControlUnderMouse)
            'If Not Equals(controlUnderMouse, _viewer) Then Return False
            If Not IsViewerFormActive() Then Return False
    
            Dim _documentControl = FindFirstDocumentControl(_viewer)
            If _documentControl Is Nothing Then Return False
            Dim screenRectangle = _documentControl.RectangleToScreen(_documentControl.ClientRectangle)
            If Not screenRectangle.Contains(mouseAbsolutePosition) Then Return False
    
            Dim delta = m.WParam.ToInt32() >> 16
            Dim newZoomLevel As Integer = CalcNewZoomLevel(_documentControl, delta)
            If (newZoomLevel < 3) Then Return False
    
            _viewer.Zoom(newZoomLevel)
            Return True
        End Function
    
        Private Function IsViewerFormActive() As Boolean
            Dim active As Boolean = False
            If _viewerForm Is Nothing Then _viewerForm = _viewer.FindForm
            Dim activeForm = Form.ActiveForm
            If activeForm IsNot Nothing AndAlso activeForm.IsMdiContainer AndAlso _viewerForm.IsMdiChild Then
                active = Equals(activeForm.ActiveMdiChild, _viewerForm)
            Else
                active = Equals(activeForm, _viewerForm)
            End If
            Return active
        End Function
    
        Private Function CalcNewZoomLevel(_documentControl As DocumentControl, delta As Integer) As Integer
            Dim newZoomLevel = _ZoomLevel
    
            If newZoomLevel < 3 Then
                Dim rpt = TryCast(_viewer.ReportSource, ReportDocument)
                If rpt Is Nothing Then Return -1
    
                Using g = _viewer.CreateGraphics()
                    If _ZoomLevel = 1 Then
                        newZoomLevel = CInt((_documentControl.ClientSize.Width / GetPageWith(rpt, g)) * 100)
                    ElseIf _ZoomLevel = 2 Then
                        newZoomLevel = CInt((_documentControl.ClientSize.Height / GetPageHeight(rpt, g)) * 100)
                    End If
                End Using
    
            End If
    
    
            newZoomLevel += (If(delta < 0, -1, 1) * CInt(newZoomLevel * ZOOM_LEVEL_DELTA_PERC / 100))
            Return newZoomLevel
        End Function
    
        Private Function GetPageHeight(rpt As ReportDocument, g As Graphics) As Integer
            Dim twips = rpt.PrintOptions.PageContentHeight + rpt.PrintOptions.PageMargins.topMargin + rpt.PrintOptions.PageMargins.bottomMargin
            Return CInt(CDbl(twips) * (1.0 / 1440.0) * g.DpiY)
        End Function
    
        Private Function GetPageWith(rpt As ReportDocument, g As Graphics) As Integer
            Dim twips = rpt.PrintOptions.PageContentWidth + rpt.PrintOptions.PageMargins.leftMargin + rpt.PrintOptions.PageMargins.rightMargin
            Return CInt(CDbl(twips) * (1.0 / 1440.0) * g.DpiX)
        End Function
    
        Private Function FindFirstDocumentControl(parent As Control) As DocumentControl
            Dim docCrtl As DocumentControl = Nothing
            For Each c As Control In parent.Controls
                If TypeOf c Is DocumentControl Then
                    docCrtl = DirectCast(c, DocumentControl)
                    Exit For
                Else
                    docCrtl = FindFirstDocumentControl(c)
                End If
                If docCrtl IsNot Nothing Then Exit For
            Next
            Return docCrtl
        End Function
    End Class
