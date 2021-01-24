    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim di As New IO.DirectoryInfo(path)
        Dim dirXML As XElement = XMLTreeView(di)
        Dim totalFiles As Integer = (From el In dirXML...<FilesInFolder>
                                        Let tf = Integer.Parse(el.Value)
                                        Select tf).Sum
        Dim totalLength As Long = (From el In dirXML...<Size>
                                    Let tl = Long.Parse(el.Value)
                                    Select tl).Sum
    End Sub
    Private Function XMLTreeView(dir As IO.DirectoryInfo) As XElement
        Dim base As XElement = <Directory name=<%= dir.Name %>>
                               </Directory>
        DoSubDirs(dir, base)
        Return base
    End Function
    Private Sub DoSubDirs(dir As IO.DirectoryInfo, info As XElement)
        For Each di As IO.DirectoryInfo In dir.GetDirectories
            Try
                Dim subXE As XElement = <SubDirectory name=<%= di.Name %>>
                                            <FilesInFolder><%= di.GetFiles.Length.ToString %></FilesInFolder>
                                        </SubDirectory>
                For Each fi As IO.FileInfo In di.GetFiles
                    Dim fileXE As XElement = <File name=<%= fi.Name %>>
                                             </File>
                    IncludeInfo(fi, fileXE)
                    subXE.Add(fileXE)
                Next
                DoSubDirs(di, subXE)
                info.Add(subXE)
            Catch ex As Exception
                'todo errors
                'probably permissions
            End Try
        Next
    End Sub
    Private Sub IncludeInfo(info As IO.FileInfo, xe As XElement)
        xe.Add(<Attributes><%= info.Attributes %></Attributes>)
        xe.Add(<Size><%= info.Length %></Size>)
        xe.Add(<CreationTime><%= info.CreationTime %></CreationTime>)
        xe.Add(<LastAccess><%= info.LastAccessTime %></LastAccess>)
        xe.Add(<LastModified><%= info.LastWriteTime %></LastModified>)
    End Sub
