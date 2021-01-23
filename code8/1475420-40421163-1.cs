    Public Class DPS : Inherits DPSBaseClass
    
        Public Category As DPSCategory
    
        Public Sub New(path As String)
            MyBase.New(XElement.Load(path))
        End Sub
    
        Public Sub New(element As XElement)
            MyBase.New(element)
            If Me.OnePart IsNot Nothing Then
                Me.Category = New DPSCategory(Me.OnePart)
            End If
        End Sub
    End Class
    
    Public Class DPSCategory : Inherits DPSBaseClass
    
        Public Device As DPSDevice
    
        Public Sub New(element As XElement)
            MyBase.New(element)
            If Me.OnePart IsNot Nothing Then
                Me.Device = New DPSDevice(Me.OnePart)
            End If
        End Sub
    End Class
    
    Public Class DPSDevice : Inherits DPSBaseClass
    
        Public Tariff As DPSTariff
    
        Public Sub New(element As XElement)
            MyBase.New(element)
            If Me.OnePart IsNot Nothing Then
                Me.Tariff = New DPSTariff(Me.OnePart)
            End If
        End Sub
    End Class
    
    Public Class DPSTariff : Inherits DPSBaseClass
    
        Public SubCategory As DPSSubCategory
    
        Public Sub New(element As XElement)
            MyBase.New(element)
            If Me.OnePart IsNot Nothing Then
                Me.SubCategory = New DPSSubCategory(Me.OnePart)
            End If
        End Sub
    End Class
    
    Public Class DPSSubCategory : Inherits DPSBaseClass
    
        Public Row As DPSSubCategoryRow
    
        Public Sub New(element As XElement)
            MyBase.New(element)
            If Me.OnePart IsNot Nothing Then
                Me.Row = New DPSSubCategoryRow(Me.OnePart)
            End If
        End Sub
    End Class
    
    Public Class DPSSubCategoryRow : Inherits DPSBaseClass
    
        Public Sub New(element As XElement)
            MyBase.New(element)
        End Sub
    End Class
    
    Public MustInherit Class DPSBaseClass
    
        Private TheData As XElement
        Private DataParts As New List(Of XElement)
        Public OnePart As XElement
    
        Public Sub New(path As String)
            Me.New(XElement.Load(path))
        End Sub
    
        Public Sub New(element As XElement)
            Me.TheData = element
            Me.GetDataParts()
        End Sub
    
        Public Sub GetDataParts()
            Me.DataParts = (From el In Me.TheData.Elements Select el).ToList
            Me.GetOnePart("")
        End Sub
    
        Public Sub GetOnePart(ID As String)
            If Me.DataParts.Count > 0 Then
                If ID <> "" Then
                    Me.OnePart = (From el In Me.DataParts Where el.@ID = ID Select el Take 1).FirstOrDefault
                Else
                    Me.OnePart = Me.DataParts.FirstOrDefault
                End If
            End If
        End Sub
    
    End Class
