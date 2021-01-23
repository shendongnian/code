    Module Module1
    
        Sub Main()
            Dim result = MyFunc(3)
            Console.WriteLine(result)
        End Sub
    
        Function MyFunc(ByVal variableName As Int16) As MyEnum
    
            Select Case variableName
                Case 1
                    Return MyEnum.ValueOne
                Case 2
                    Return MyEnum.ValueTwo
                'Case Else
                    'Throw New ArgumentException("Invalid value")
            End Select
        End Function
    
    End Module
    
    Enum MyEnum
        ValueOne
        ValueTwo
    End Enum
