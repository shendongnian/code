    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Form1
    	Inherits System.Windows.Forms.Form
    
    	'Form overrides dispose to clean up the component list.
    	<System.Diagnostics.DebuggerNonUserCode()> _
    	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    		Try
    			If disposing AndAlso components IsNot Nothing Then
    				components.Dispose()
    			End If
    		Finally
    			MyBase.Dispose(disposing)
    		End Try
    	End Sub
    
    	'Required by the Windows Form Designer
    	Private components As System.ComponentModel.IContainer
    
    	'NOTE: The following procedure is required by the Windows Form Designer
    	'It can be modified using the Windows Form Designer.  
    	'Do not modify it using the code editor.
    	<System.Diagnostics.DebuggerStepThrough()> _
    	Private Sub InitializeComponent()
    		Me.components = New System.ComponentModel.Container()
    		Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
    		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    		Me.Label2 = New System.Windows.Forms.Label()
    		Me.Pic = New System.Windows.Forms.PictureBox()
    		Me.Label1 = New System.Windows.Forms.Label()
    		Me.txtInterval = New System.Windows.Forms.TextBox()
    		Me.Button1 = New System.Windows.Forms.Button()
    		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
    		Me.SplitContainer1.Panel1.SuspendLayout
    		Me.SplitContainer1.Panel2.SuspendLayout
    		Me.SplitContainer1.SuspendLayout
    		CType(Me.Pic,System.ComponentModel.ISupportInitialize).BeginInit
    		Me.SuspendLayout
    		'
    		'GMapControl1
    		'
    		Me.GMapControl1.Bearing = 0!
    		Me.GMapControl1.CanDragMap = true
    		Me.GMapControl1.Dock = System.Windows.Forms.DockStyle.Fill
    		Me.GMapControl1.EmptyTileColor = System.Drawing.Color.Navy
    		Me.GMapControl1.GrayScaleMode = false
    		Me.GMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
    		Me.GMapControl1.LevelsKeepInMemmory = 5
    		Me.GMapControl1.Location = New System.Drawing.Point(0, 0)
    		Me.GMapControl1.MarkersEnabled = true
    		Me.GMapControl1.MaxZoom = 20
    		Me.GMapControl1.MinZoom = 2
    		Me.GMapControl1.MouseWheelZoomEnabled = true
    		Me.GMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
    		Me.GMapControl1.Name = "GMapControl1"
    		Me.GMapControl1.NegativeMode = false
    		Me.GMapControl1.PolygonsEnabled = true
    		Me.GMapControl1.RetryLoadTile = 0
    		Me.GMapControl1.RoutesEnabled = true
    		Me.GMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
    		Me.GMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33,Byte),Integer), CType(CType(65,Byte),Integer), CType(CType(105,Byte),Integer), CType(CType(225,Byte),Integer))
    		Me.GMapControl1.ShowTileGridLines = false
    		Me.GMapControl1.Size = New System.Drawing.Size(639, 556)
    		Me.GMapControl1.TabIndex = 0
    		Me.GMapControl1.Zoom = 0R
    		'
    		'SplitContainer1
    		'
    		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    		Me.SplitContainer1.Name = "SplitContainer1"
    		'
    		'SplitContainer1.Panel1
    		'
    		Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    		Me.SplitContainer1.Panel1.Controls.Add(Me.Pic)
    		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    		Me.SplitContainer1.Panel1.Controls.Add(Me.txtInterval)
    		Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
    		'
    		'SplitContainer1.Panel2
    		'
    		Me.SplitContainer1.Panel2.Controls.Add(Me.GMapControl1)
    		Me.SplitContainer1.Size = New System.Drawing.Size(816, 556)
    		Me.SplitContainer1.SplitterDistance = 173
    		Me.SplitContainer1.TabIndex = 1
    		'
    		'Label2
    		'
    		Me.Label2.AutoSize = true
    		Me.Label2.Location = New System.Drawing.Point(54, 31)
    		Me.Label2.Name = "Label2"
    		Me.Label2.Size = New System.Drawing.Size(70, 13)
    		Me.Label2.TabIndex = 4
    		Me.Label2.Text = "Active Image"
    		'
    		'Pic
    		'
    		Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    		Me.Pic.Location = New System.Drawing.Point(52, 54)
    		Me.Pic.Name = "Pic"
    		Me.Pic.Size = New System.Drawing.Size(72, 65)
    		Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    		Me.Pic.TabIndex = 3
    		Me.Pic.TabStop = false
    		'
    		'Label1
    		'
    		Me.Label1.AutoSize = true
    		Me.Label1.Location = New System.Drawing.Point(21, 154)
    		Me.Label1.Name = "Label1"
    		Me.Label1.Size = New System.Drawing.Size(134, 13)
    		Me.Label1.TabIndex = 2
    		Me.Label1.Text = "Time Interval (miliseconds)"
    		'
    		'txtInterval
    		'
    		Me.txtInterval.Location = New System.Drawing.Point(45, 172)
    		Me.txtInterval.Name = "txtInterval"
    		Me.txtInterval.Size = New System.Drawing.Size(83, 20)
    		Me.txtInterval.TabIndex = 1
    		Me.txtInterval.Text = "500"
    		'
    		'Button1
    		'
    		Me.Button1.Location = New System.Drawing.Point(33, 211)
    		Me.Button1.Name = "Button1"
    		Me.Button1.Size = New System.Drawing.Size(107, 29)
    		Me.Button1.TabIndex = 0
    		Me.Button1.Text = "Start"
    		Me.Button1.UseVisualStyleBackColor = true
    		'
    		'Timer1
    		'
    		Me.Timer1.Interval = 1000
    		'
    		'Form1
    		'
    		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    		Me.ClientSize = New System.Drawing.Size(816, 556)
    		Me.Controls.Add(Me.SplitContainer1)
    		Me.Name = "Form1"
    		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    		Me.Text = "Form1"
    		Me.SplitContainer1.Panel1.ResumeLayout(false)
    		Me.SplitContainer1.Panel1.PerformLayout
    		Me.SplitContainer1.Panel2.ResumeLayout(false)
    		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
    		Me.SplitContainer1.ResumeLayout(false)
    		CType(Me.Pic,System.ComponentModel.ISupportInitialize).EndInit
    		Me.ResumeLayout(false)
    
    End Sub
    
    	Friend WithEvents GMapControl1 As GMap.NET.WindowsForms.GMapControl
    	Friend WithEvents SplitContainer1 As SplitContainer
    	Friend WithEvents Label2 As Label
    	Friend WithEvents Pic As PictureBox
    	Friend WithEvents Label1 As Label
    	Friend WithEvents txtInterval As TextBox
    	Friend WithEvents Button1 As Button
    	Friend WithEvents Timer1 As Timer
    End Class
