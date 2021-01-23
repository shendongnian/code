    Private Sub OnFormLoad() Handles Me.Load
        txtFile.Text = My.Settings.lastpath
        If txtFile.Text <> "" Then
            cmdOpen.Enabled = True
            cmdOpen.Select()
        Else
            cmdNew.Select()
        End If
    End Sub
    Private Sub FileSelect()
        Try
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "sdf files (*.sdf)|*.sdf|All files (*.*)|*.*"
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True
            Dim result As DialogResult = openFileDialog.ShowDialog(Me)
            If result = DialogResult.Cancel Then
                cmdSelectDatabase.Select()
                Exit Sub
            End If
            Dim strPathandFile As String = openFileDialog.FileName
            txtFile.Text = strPathandFile
            If txtFile.Text <> "" Then
                cmdOpen.Enabled = True
                cmdOpen.Select()
                My.Settings.lastpath = strPathandFile
                My.Settings.Save()
            Else
                cmdOpen.Enabled = False
                cmdSelectDatabase.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Application Error")
            Application.Exit()
        Finally
        End Try
    End Sub 
    Private Sub SetConnectionString()
        Try
            Dim providerName As String = "System.Data.SqlServerCe.4.0"
            Dim datasource As String = txtFile.Text
            Dim password As String = txtPassword.Text
            Dim sqlCeBuilder As New SqlCeConnectionStringBuilder
            sqlCeBuilder.DataSource = datasource
            sqlCeBuilder.Password = password
            sqlCeBuilder.PersistSecurityInfo = True
            g_SQLCeConnectionString = sqlCeBuilder.ConnectionString
            Dim providerString As String = sqlCeBuilder.ToString()
            Dim entityBuilder As New EntityConnectionStringBuilder()
            entityBuilder.Provider = providerName
            entityBuilder.ProviderConnectionString = providerString
            entityBuilder.Metadata = "res://*/RecipeModel.csdl|res://*/RecipeModel.ssdl|res://*/RecipeModel.msl"
            Dim c As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Dim section As ConnectionStringsSection = DirectCast(c.GetSection("connectionStrings"), ConnectionStringsSection)
            g_EntityConnectionString = entityBuilder.ConnectionString
            section.ConnectionStrings("RecipeEntities").ConnectionString = g_EntityConnectionString
            c.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("connectionStrings")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Application Error")
            Application.Exit()
        End Try
    End Sub 
    Private Sub CreateDatabase()
        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "sdf files (*.sdf)|*.sdf"
            saveFileDialog.Title = "Create Database"
            saveFileDialog.FilterIndex = 1
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                File.Copy(Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, "rw.sdf"), saveFileDialog.FileName, True)
                Dim strPathandFile As String = saveFileDialog.FileName
                txtFile.Text = strPathandFile
                My.Settings.lastpath = strPathandFile
                My.Settings.Save()
                cmdOpen.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Application Error")
            Application.Exit()
        End Try
    End Sub
    Private Sub LoadMainApplication()
        Try
            Dim objNewForm As New FrmMain
            objNewForm.Show()
            Me.Close()
       
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Application Error")
            Application.Exit()
        End Try
    End Sub
