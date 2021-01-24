    Private Sub ProcessAssignments(T As Task)
        Dim A As Assignment
        Dim tsvsHours As TimeScaleValues
        Dim tsvsCosts0 As TimeScaleValues
        Dim dblWork As Double
        Dim curCostClassA As Double
        ' Process assignments
        For Each A In T.Assignments
            ' Get the timescale collection objects for Hours and Costs
            tsvsHours = A.TimeScaleData(
                StartDate:=T.Start,
                EndDate:=T.Finish,
                Type:=PjAssignmentTimescaledData.pjAssignmentTimescaledBaselineWork,
                TimeScaleUnit:=PjTimescaleUnit.pjTimescaleMonths,
                Count:=1)
            tsvsCosts0 = A.TimeScaleData(
                StartDate:=T.Start,
                EndDate:=T.Finish,
                Type:=PjAssignmentTimescaledData.pjAssignmentTimescaledBaselineCost,
                TimeScaleUnit:=PjTimescaleUnit.pjTimescaleMonths,
                Count:=1)
            ' Iterate through the assignment timescalevalues
            For i As Integer = 1 To tsvsCosts0.Count
                If IsNumeric(tsvsCosts0(i).Value) = True Then 'Cannot process non-working times with an empty string value
                    ' Get the hours from the tsvsHours collection
                    If IsNumeric(tsvsHours(i).Value) Then
                        dblWork = CDbl(tsvsHours(i).Value / 60)
                    Else
                        dblWork = 0
                    End If
                    ' Get the costs from the Baseline collection
                    If IsNumeric(tsvsCosts0(i).Value) Then
                        curCostClassA = tsvsCosts0(i).Value
                    Else
                        curCostClassA = 0
                    End If
                    ' Do stuff here
                End If
            Next i
            tsvsHours = Nothing
            tsvsCosts0 = Nothing
        Next A
    End Sub
