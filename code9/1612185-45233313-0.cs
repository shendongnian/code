    Public Class clsDgvHexColumn
      Inherits DataGridViewTextBoxColumn
    
      Private mFont             As System.Drawing.Font
    
      public sub New
        MyBase.CellTemplate = new clsDgvHexColumnCell
        mFont = New System.Drawing.Font ( "Consolas", 10 )
      End Sub
    
      Public Property Font As Font
        Get
          Return mFont
        End Get
        Set(ByVal value As Font)
          mFont = value
          Me.DefaultCellStyle.Font = mFont
        End Set
      End Property
    
    Public Shared Sub Handler_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs)
          Dim dgv as Your_Type //This is the type of dgvValues (which is DataGridView) I suppose, Replace Your_Type appropriately
          dgv = CType(sender,Your_Type)
          If     dgv.Columns(e.ColumnIndex).Name = "NewDAC" _
          OrElse dgv.Columns(e.ColumnIndex).Name = "NewOffset" _
          OrElse dgv.Columns(e.ColumnIndex).Name = "New80PercentValue" _
          Then
    
        If e IsNot Nothing AndAlso e.Value IsNot Nothing Then
          Try
            Dim InputString   As String = TryCast(e.Value, String)
            Dim newValue      As Int32  = TypeDescriptor.GetConverter(newValue).ConvertFrom(InputString)
            Dim bytes         As Byte() = BitConverter.GetBytes(newValue)
    
            If e.DesiredType.Equals(GetType(UInt16)) Then
              e.Value = BitConverter.ToUInt16 ( bytes, 0 )
            ElseIf e.DesiredType.Equals(GetType(Int16)) Then
              e.Value = BitConverter.ToInt16 ( bytes, 0 )
            ElseIf e.DesiredType.Equals(GetType(UInt32)) Then
              e.Value = BitConverter.ToUInt32 ( bytes, 0 )
            ElseIf e.DesiredType.Equals(GetType(Int32)) Then
              e.Value = newValue
            End If
    
            e.ParsingApplied = True
          Catch
    
          End Try
        End If
    
      End If
    
    End Sub
    End Class
