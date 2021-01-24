    ''' <summary>
    ''' Caches an enum underlying value getter delegate.
    ''' </summary>
    ''' <typeparam name="TEnum">Enum type</typeparam>
    Public Class CachedEnumUnderlyingValueAccess(Of TEnum)
        Private Shared underlyingTypeValueGetter As Func(Of TEnum, Object) = CreateUnderlyingTypeValueGetter()
    
        Private Shared Function CreateUnderlyingTypeValueGetter()
            Dim enumUnderlyingType As Type = [Enum].GetUnderlyingType(GetType(TEnum))
            Dim enumParameter As ParameterExpression = Expression.Parameter(GetType(TEnum))
            'Convert the enum parameter to its underlying type, then convert it to an Object
            Dim conversionExpression As Expression(Of Func(Of TEnum, Object)) = Expression.Lambda(Expression.Convert(Expression.Convert(enumParameter, enumUnderlyingType), GetType(Object)), enumParameter)
            Return conversionExpression.Compile()
        End Function
    
        Public Shared Function GetEnumUnderlyingValue(val As TEnum) As Object
            Return underlyingTypeValueGetter.Invoke(val)
        End Function
    End Class
