    Public Shared Sub LockFormRegionToControls(ByVal f As Form)
    	Dim r As New Region()
    	r.MakeEmpty()
    	For Each c As Control In f.Controls
    		Using r2 As New Region(c.Bounds)
    			r.Union(r2)
    		End Using
    	Next
    	Dim oldRegion As Region = f.Region
    	f.Region = r
    	If oldRegion IsNot Nothing Then oldRegion.Dispose()
    End Sub
 
