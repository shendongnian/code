    Public Class MaskedEditColumn
        Inherits DataGridViewColumn
        Public Sub New()
            MyBase.New(New MaskedEditCell())
        End Sub
        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)
    
                ' Ensure that the cell used for the template is a CalendarCell.
                If Not (value Is Nothing) AndAlso
                    Not value.GetType().IsAssignableFrom(GetType(MaskedEditCell)) _
                    Then
                    Throw New InvalidCastException("Must be a MaskedEditCell")
                End If
                MyBase.CellTemplate = value
            End Set
        End Property
        Private m_strMask As String
        Public Property Mask() As String
            Get
                Return m_strMask
            End Get
            Set(ByVal value As String)
                m_strMask = value
            End Set
        End Property
        Private m_tyValidatingType As Type
        Public Property ValidatingType() As Type
            Get
                Return m_tyValidatingType
            End Get
            Set(ByVal value As Type)
                m_tyValidatingType = value
            End Set
        End Property
        Private m_cPromptChar As Char = "_"c
        Public Property PromptChar() As Char
            Get
                Return m_cPromptChar
            End Get
            Set(ByVal value As Char)
                m_cPromptChar = value
            End Set
        End Property
        Private ReadOnly Property MaskedEditCellTemplate() As MaskedEditCell
            Get
                Return TryCast(Me.CellTemplate, MaskedEditCell)
            End Get
        End Property
    End Class
    Public Class MaskedEditCell
        Inherits DataGridViewTextBoxCell
        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
            ByVal initialFormattedValue As Object,
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)
            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle)
            Dim mecol As MaskedEditColumn = DirectCast(OwningColumn, MaskedEditColumn)
            Dim ctl As MaskedEditingControl =
                CType(DataGridView.EditingControl, MaskedEditingControl)
            Try
                ctl.Text = Me.Value.ToString
            Catch
                ctl.Text = ""
            End Try
            ctl.Mask = mecol.Mask
            ctl.PromptChar = mecol.PromptChar
            ctl.ValidatingType = mecol.ValidatingType
        End Sub
        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing contol that CalendarCell uses.
                Return GetType(MaskedEditingControl)
            End Get
        End Property
        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains.
                Return GetType(String)
            End Get
        End Property
        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value.
                Return ""
            End Get
        End Property
        Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        End Sub
    End Class
    Class MaskedEditingControl
        Inherits MaskedTextBox
        Implements IDataGridViewEditingControl
        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer
        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue
            Get
                Return Me.Text
            End Get
            Set(ByVal value As Object)
                Me.Text = value.ToString
            End Set
        End Property
        Public Function EditingControlWantsInputKey(ByVal key As Keys,
               ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
               Implements IDataGridViewEditingControl.EditingControlWantsInputKey
            Return True
        End Function
        Public Function GetEditingControlFormattedValue(ByVal context _
            As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
            Return Me.Text
        End Function
        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
            DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
    
            Me.Font = dataGridViewCellStyle.Font
            Me.ForeColor = dataGridViewCellStyle.ForeColor
            Me.BackColor = dataGridViewCellStyle.BackColor
        End Sub
        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex
            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set
        End Property
        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
            ' No preparation needs to be done.
        End Sub
        Public ReadOnly Property RepositionEditingControlOnValueChange() _
            As Boolean Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange
            Get
                Return False
            End Get
        End Property
        Public Property EditingControlDataGridView() As DataGridView _
            Implements IDataGridViewEditingControl.EditingControlDataGridView
            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set
        End Property
    
        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged
            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set
        End Property
        Public ReadOnly Property EditingControlCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor
            Get
                Return MyBase.Cursor
            End Get
        End Property
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            ' Notify the DataGridView that the contents of the cell have changed.
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnTextChanged(e)
        End Sub
    End Class
