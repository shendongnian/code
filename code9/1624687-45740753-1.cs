    Module myModule
       Private something As String   //This here is a Field
       //Below is the code for a read-only property
       Public Property SomethingWhichIsReadOnly As String
         //SomethingWhichIsReadOnly can be used from anywhere
         Get
            Return something         
         End Get
       End Property
       Public Function SomeFunction(ByVal value as Integer) As Boolean
          ...
          //You can use "something"(String Field declared above) in functions
          //Which can be accessed and modified only from the module itself
       End Function
    End Module
