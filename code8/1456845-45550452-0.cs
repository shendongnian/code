    Namespace GMap.NET.WindowsForms.Markers
    Public Class GMapMarkerBoat
        Inherits GMapMarker
        Public Brush As Brush
        Public boatHeading As Double
        Public Sub New(ic As SEAS_DATA.ImageCluster, b As Brush)
            MyBase.New(ic.LatLong)
            boatHeading = ic.IMU_Heading
            Brush = b
            'Size of the marker
            Size = New Size(8, 8)
        End Sub
        Public Overrides Sub OnRender(g As Graphics)
            Dim newSize As Size
            Dim maxZoomLevel As Integer = SEAS_Forms.frmMain.myMap.MaxZoom
            Select Case SEAS_Forms.frmMain.myMap.Zoom
                Case maxZoomLevel
                    newSize = New Size(Size.Width * 2, Size.Height * 2)
                Case maxZoomLevel - 1 To maxZoomLevel
                    newSize = New Size(CInt(Size.Width * 1.5), CInt(Size.Height * 1.5))
                Case maxZoomLevel - 2 To maxZoomLevel - 1
                    newSize = Size
                Case SEAS_Forms.frmMain.myMap.MinZoom To maxZoomLevel - 2
                    newSize = New Size(CInt(Size.Width / 2), CInt(Size.Height / 2))
            End Select
            'boat
            Dim boat(4) As PointF
            boat(0).X = CSng(-newSize.Width / 2)
            boat(0).Y = CSng(-newSize.Height / 2)
            boat(1).X = (boat(0).X + newSize.Width)
            boat(1).Y = boat(0).Y
            boat(3).X = boat(0).X
            boat(3).Y = (boat(0).Y + newSize.Height)
            boat(2).X = boat(1).X
            boat(2).Y = boat(3).Y
            boat(4).X = CSng(boat(0).X - newSize.Width / 2)
            boat(4).Y = CSng(boat(0).Y + newSize.Width / 2)
            If SEAS_Forms.frmMain.myMap.Zoom > maxZoomLevel - 4 Then
                boat = TransformAndRotate(boatHeading, boat) 'simplified rotation and transformation matrix
            Else
                boat = TransformAndRotate(0, boat)
            End If
            'start drawing here
            Select Case SEAS_Forms.frmMain.myMap.Zoom
                Case maxZoomLevel - 3 To maxZoomLevel
                    g.FillPolygon(Brush, boat)
                Case SEAS_Forms.frmMain.myMap.MinZoom To maxZoomLevel - 3
                    Dim newRect As New RectangleF(boat(0).X, boat(0).Y, newSize.Width, newSize.Height)
                    g.FillEllipse(Brush, newRect)
            End Select
        End Sub
        Private Function TransformAndRotate(heading As Double, points() As PointF) As PointF()
            Dim cosRot As Double = Math.Cos((heading + 90) * Math.PI / 180)
            Dim sinRot As Double = Math.Sin((heading + 90) * Math.PI / 180)
            For i = 0 To points.Length - 1
                Dim x As Single = points(i).X
                Dim y As Single = points(i).Y
                points(i).X = CSng((LocalPosition.X) + (x * cosRot - y * sinRot)) 'simplified rotation and transformation matrix
                points(i).Y = CSng((LocalPosition.Y) + (x * sinRot + y * cosRot))
            Next
            Return points
        End Function
    End Class
    End Namespace
