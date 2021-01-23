    Public Class DynamicFilterOnTwoTextItems
    
      Public Class ProductSku
        Public Property ProductId As Integer
        Public Property SkuID As Integer
        Public Property Description As String
      End Class
    
      Private _products As List(Of ProductSku) = New List(Of ProductSku)
      Private _initialLoadDone As Boolean = False
    
      Private Sub DynamicComboBoxDoubleFill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AutoGenerateColumns = False
    
        Dim products = New List(Of ProductSku)({
                                         New ProductSku With {.ProductId = 1, .SkuID = 1, .Description = "Offline"},
                                         New ProductSku With {.ProductId = 1, .SkuID = 2, .Description = "Offline2"},
                                         New ProductSku With {.ProductId = 2, .SkuID = 1, .Description = "Online"},
                                         New ProductSku With {.ProductId = 2, .SkuID = 2, .Description = "Online2"}
                                         })
    
        Dim s = ""
        For Each o In _products
          Dim row As DataRow = ds.Tables("tProducts").NewRow
          row("ProductId") = o.ProductId
          row("SkuID") = o.SkuID
          row("Desc") = o.Description
          ds.Tables("tProducts").Rows.Add(row)
        Next
    
        dgv.AutoGenerateColumns = False
        dgv.DataSource = ds.Tables("tProducts")
    
        _initialLoadDone = True
      End Sub
    
      Private Sub bFilter_Click(sender As Object, e As EventArgs) Handles bFilter.Click
    
        Dim predicate = String.Empty
    
        If String.IsNullOrEmpty(tsku.Text) Then
          predicate = $"ProductID = '{CInt(tPrd.Text)}'"
        Else
          predicate = $"ProductID = '{CInt(tPrd.Text)}' and SkuID = '{CInt(tsku.Text)}'"
        End If
        Dim dvProducts = New DataView(ds.Tables("tProducts"), predicate, "ProductID ASC", DataViewRowState.CurrentRows)
    
        dgv.DataSource = dvProducts
      End Sub
    End Class
