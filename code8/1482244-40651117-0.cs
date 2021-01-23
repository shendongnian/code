    Public Class PropertySetter
    Public Shared Sub SetObjectProperty(ByRef obj As Object, propertyInfo As PropertyInfo, propertyValue As Object)
        'if we do not need to convert propertyValue to certain type
        If IsNothing(propertyValue) OrElse propertyInfo.PropertyType = propertyValue.GetType() Then
            obj.GetType().GetProperty(propertyInfo.Name).SetValue(obj, propertyValue)
        Else
            'Convert.ChangeType does not handle conversion to nullable types
            'if the property type is nullable, we need to get the underlying type of the property
            Dim targetType = If(IsNullableType(propertyInfo.PropertyType), Nullable.GetUnderlyingType(propertyInfo.PropertyType), propertyInfo.PropertyType)
            'convert Enum
            If (propertyValue.GetType() = GetType(String)) Then
                If propertyInfo.PropertyType.IsEnum OrElse (Not Nullable.GetUnderlyingType(propertyInfo.PropertyType) Is Nothing AndAlso Nullable.GetUnderlyingType(propertyInfo.PropertyType).IsEnum) Then
                    'if propertyValue is equal to enum value
                    Try
                        propertyValue = [Enum].Parse(targetType, propertyValue.ToString())
                    Catch ex As Exception
                        'if propertyValue is equal to enum description 
                        Dim enumValues = targetType.GetFields()
                        For Each enumValue In enumValues
                            Dim descriptionAttribute = enumValue.GetCustomAttribute(Of DescriptionAttribute)()
                            If Not descriptionAttribute Is Nothing Then
                                If (descriptionAttribute.Description.Trim().ToUpper() = propertyValue.ToString().ToUpper()) Then
                                    propertyValue = enumValue.GetValue(Nothing)
                                    Exit For
                                End If
                            End If
                        Next
                    End Try
                End If
            End If
            'set object property via reflection
            obj.GetType().GetProperty(propertyInfo.Name).SetValue(obj, Convert.ChangeType(propertyValue, targetType, CultureInfo.InvariantCulture))
        End If
    End Sub
    Private Shared Function IsNullableType(type As Type) As Boolean
        Return type.IsGenericType AndAlso type.GetGenericTypeDefinition().Equals(GetType(Nullable(Of )))
    End Function
    End Class
