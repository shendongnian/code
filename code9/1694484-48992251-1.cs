    Option Explicit On
    Imports System
    Public Class Form1
    Private MyDataRow As DataRow
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim ID As Integer = Val(txtID.Text)
        If ID < 1 Then Exit Sub
        btnOpen.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = False
        btnAbort.Enabled = False
        If OpenDB() Then
    TryAgain:
            Dim ReadRow As Tuple(Of Boolean, DataRow) = ReadRecordByID(ID, chkTransaction.Checked)
            btnUpdate.Enabled = True
            If ReadRow.Item1 Then
                MyDataRow = ReadRow.Item2
                lblQty.Text = MyDataRow("Quantity")
                lblAlloc.Text = MyDataRow("Allocated")
                txtQty.Text = ""
                txtAlloc.Text = ""
                If Not chkTransaction.Checked Then btnAbort.Enabled = True
            Else
                Select Case MessageBox.Show("Transaction Time Out - Unable to lock record", "Database", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question)
                    Case DialogResult.Retry
                        GoTo TryAgain
                    Case Else
                End Select
                btnOpen.Enabled = True
                btnUpdate.Enabled = False
                btnCommit.Enabled = False
                btnAbort.Enabled = False
                txtID.Select()
            End If
        Else
            btnOpen.Enabled = True
            btnUpdate.Enabled = False
            btnCommit.Enabled = False
            btnAbort.Enabled = False
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        MyDataRow("Quantity") += Val(txtQty.Text)
        MyDataRow("Allocated") += Val(txtAlloc.Text)
        If UpdateRecord(MyDataRow) Then
            If chkTransaction.Checked Then
                btnCommit.Enabled = True
                btnAbort.Enabled = True
                btnUpdate.Enabled = False
            Else
                btnOpen.Enabled = True
                btnCommit.Enabled = False
                btnAbort.Enabled = False
                btnUpdate.Enabled = False
                lblQty.Text = ""
                lblAlloc.Text = ""
                txtQty.Text = ""
                txtAlloc.Text = ""
            End If
        Else
            btnOpen.Enabled = True
            btnUpdate.Enabled = False
            btnCommit.Enabled = False
            btnAbort.Enabled = False
            lblQty.Text = ""
            lblAlloc.Text = ""
            txtQty.Text = ""
            txtAlloc.Text = ""
        End If
    End Sub
    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        CommitTransaction()
        lblQty.Text = ""
        lblAlloc.Text = ""
        txtQty.Text = ""
        txtAlloc.Text = ""
        btnOpen.Enabled = True
        btnCommit.Enabled = False
        btnAbort.Enabled = False
        CloseDB()
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        AbortTransaction()
        lblQty.Text = ""
        lblAlloc.Text = ""
        txtQty.Text = ""
        txtAlloc.Text = ""
        btnOpen.Enabled = True
        btnUpdate.Enabled = False
        btnCommit.Enabled = False
        btnAbort.Enabled = False
        CloseDB()
    End Sub
    End Class
