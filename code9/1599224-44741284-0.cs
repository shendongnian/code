    Public Structure OVERNIGHT_CONFIG
        Public AMOUNT As Double
        Public StartTime As Date
        Public GracePeriod As Long
        Public TimeIN As Date
        Public TimeOut As Date
        Public Is24 As Boolean
    End Structure
    Public Structure OVERNIGHT_RESULT
        Public OVERNIGHT_COUNT As Integer
        Public DAYS_COUNT As Integer
        Public AMOUNT As Double
    End Structure
    
    Public Shared Function GET_OVERNIGHT(ByVal O As OVERNIGHT_CONFIG) As OVERNIGHT_RESULT
        Dim ax As Date = O.TimeIN
        Dim bx As Date = O.TimeOut
        Dim R As New OVERNIGHT_RESULT
        If O.Is24 = True Then
            Dim d As Long = DateDiff(DateInterval.Day, O.TimeIN, O.TimeOut)
            R.DAYS_COUNT = d
            R.OVERNIGHT_COUNT = d
            R.AMOUNT = O.AMOUNT * d
            Return R
        End If
        R.DAYS_COUNT = 0
        R.AMOUNT = 0
        R.OVERNIGHT_COUNT = 0
        If ax.Date = bx.Date Then Return R
        Dim StartTime As Date = CDate(ax.Date & " " & O.StartTime)
        Dim EndTime As Date = DateAdd(DateInterval.Hour, O.GracePeriod, StartTime)
        Dim Res As Integer = DateTime.Compare(ax, StartTime)
        If Res = 1 Then Return R
        Res = DateTime.Compare(bx, EndTime)
        If Res = -1 Then Return R
        'Code Block (c)2017 CodingYoshi === StockOverFlow ======>>>>>'
        Dim dayStart = DateTime.Parse(ax)
        Dim dayLast = DateTime.Parse(bx)
        Dim addOneForLastDay As Boolean = False
        Dim DL As Integer = dayLast.Hour & dayLast.Minute
        Dim ET As Integer = EndTime.Hour & EndTime.Minute
        If DL >= ET Then
            addOneForLastDay = True
        End If
        Dim ExCount = Convert.ToInt32(dayLast.[Date].AddMinutes(-1).Subtract(dayStart.AddDays(1).[Date]).TotalDays)
        If addOneForLastDay Then
            ExCount += 1
        End If
        '====== End ============================================>>>>'
        With R
            .OVERNIGHT_COUNT = ExCount
            .AMOUNT += O.AMOUNT * ExCount
        End With
        Return R
    End Function
