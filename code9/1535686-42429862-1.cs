    Public Sub CopyStream(source As Stream, destination As Stream, Optional blockSize As Integer = 1024)
        Dim buffer(blockSize - 1) As Byte
        'Read the first block.'
        Dim bytesRead = source.Read(buffer, 0, blockSize)
        Do Until bytesRead = 0
            'Write the current block.'
            destination.Write(buffer, 0, bytesRead)
            'Read the next block.'
            bytesRead = source.Read(buffer, 0, blockSize)
        Loop
    End Sub
