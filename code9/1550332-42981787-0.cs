	Public Class XMLPlusSerializer
		Inherits XmlSerializer
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(type As Type)
			MyBase.New(type)
		End Sub
		Public Sub New(xmlTypeMapping As XmlTypeMapping)
			MyBase.New(xmlTypeMapping)
		End Sub
		Public Sub New(type As Type, defaultNamespace As String)
			MyBase.New(type, defaultNamespace)
		End Sub
		Public Sub New(type As Type, extraTypes() As Type)
			MyBase.New(type, extraTypes)
		End Sub
		Public Sub New(type As Type, objOverrides As XmlAttributeOverrides)
			MyBase.New(type, objOverrides)
		End Sub
		Public Sub New(type As Type, root As XmlRootAttribute)
			MyBase.New(type, root)
		End Sub
		Public Sub New(type As Type, objOverrides As XmlAttributeOverrides, extraTypes() As Type, root As XmlRootAttribute, defaultNamespace As String)
			MyBase.New(type, objOverrides, extraTypes, root, defaultNamespace)
		End Sub
		Public Sub New(type As Type, objOverrides As XmlAttributeOverrides, extraTypes() As Type, root As XmlRootAttribute, defaultNamespace As String, location As String)
			MyBase.New(type, objOverrides, extraTypes, root, defaultNamespace, location)
		End Sub
		Public Shadows Function Deserialize(stream As Stream) As Object
			Dim ret = MyBase.Deserialize(stream)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Public Shadows Function Deserialize(textReader As TextReader) As Object
			Dim ret = MyBase.Deserialize(textReader)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Public Shadows Function Deserialize(reader As XmlSerializationReader) As Object
			Dim ret = MyBase.Deserialize(reader)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Public Shadows Function Deserialize(xmlReader As XmlReader, encodingStyle As String) As Object
			Dim ret = MyBase.Deserialize(xmlReader, encodingStyle)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Public Shadows Function Deserialize(xmlReader As XmlReader, events As XmlDeserializationEvents) As Object
			Dim ret = MyBase.Deserialize(xmlReader, events)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Public Shadows Function Deserialize(xmlReader As XmlReader, encodingStyle As String, events As XmlDeserializationEvents) As Object
			Dim ret = MyBase.Deserialize(xmlReader, encodingStyle, events)
			Dim result As XMLPlusValidateRequiredResult = ValidateRequired(ret)
			If result.IsValid = False Then
				Throw New Exception(result.ExceptionMessage)
			End If
			Return ret
		End Function
		Private Function ValidateRequired(obj As Object) As XMLPlusValidateRequiredResult
			Dim ret As New XMLPlusValidateRequiredResult()
			Try
				Dim arrPI() As PropertyInfo = obj.GetType().GetProperties(BindingFlags.Public Or BindingFlags.Instance)
				For Each pi As PropertyInfo In arrPI
					Dim xmlAttributeRequired As Attribute = pi.GetCustomAttribute(GetType(XMLPlusAttributeAttribute))
					If xmlAttributeRequired IsNot Nothing Then
						' If its an attribute and is required, make sure there is a value
						Dim xmlAttributeRequiredInst As XMLPlusAttributeAttribute = DirectCast(xmlAttributeRequired, XMLPlusAttributeAttribute)
						If xmlAttributeRequiredInst.Required = True Then
							If IsNothing(pi.GetValue(obj)) = True Then
								Throw New Exception(String.Format("XML Deserialization Exception, Message = Property '{0}' can't be null or empty. Attribute '{1}' must be defined.", pi.Name, xmlAttributeRequiredInst.AttributeName))
							Else
								If pi.PropertyType = GetType(String) Then
									If DirectCast(pi.GetValue(obj), String) = String.Empty Then
										Throw New Exception(String.Format("XML Deserialization Exception, Message = Property '{0}' can't be null or empty. Attribute '{1}' must be defined.", pi.Name, xmlAttributeRequiredInst.AttributeName))
									End If
								End If
							End If
						End If
					Else
						' If its an element and is required, make sure there is a value
						Dim xmlElementRequired As Attribute = pi.GetCustomAttribute(GetType(XMLPlusElementAttribute))
						If xmlElementRequired IsNot Nothing Then
							Dim xmlElementRequiredInst As XMLPlusElementAttribute = DirectCast(xmlElementRequired, XMLPlusElementAttribute)
							If xmlElementRequiredInst.Required = True Then
								Dim objElem As Object = pi.GetValue(obj)
								If IsNothing(objElem) Then
									'If its null, immediately throw an exception
									Throw New Exception(String.Format("XML Deserialization Exception, Message = Element '{0}' can't be null or empty. Must contain 1 or more instances of &lt;{1}&gt;", pi.Name, xmlElementRequiredInst.ElementName))
								Else
									Dim objType As Type = objElem.GetType()
									If objType.IsGenericType And (objType.GetGenericTypeDefinition() = GetType(List(Of ))) Then
										'If its a list, make sure Count > 0
										Dim objList As IList = DirectCast(objElem, IList)
										If objList.Count = 0 Then
											Throw New Exception(String.Format("XML Deserialization Exception, Message = Element '{0}' can't be null or empty. Must contain 1 or more instances of &lt;{1}&gt;", pi.Name, xmlElementRequiredInst.ElementName))
										Else
											'Iterate through each list item and validate the object of each
											For i As Int32 = 0 To objList.Count - 1
												Dim objItem As Object = objList(i)
												Dim result As XMLPlusValidateRequiredResult = ValidateRequired(objItem)
												If result.IsValid = False Then
													Throw New Exception(result.ExceptionMessage)
												End If
											Next
										End If
									Else
										'If its a standard singleton object, validate the object
										Dim result As XMLPlusValidateRequiredResult = ValidateRequired(objElem)
										If result.IsValid = False Then
											Throw New Exception(result.ExceptionMessage)
										End If
									End If
								End If
							End If
						End If
					End If
				Next
				ret.IsValid = True
				ret.ExceptionMessage = String.Empty
			Catch ex As Exception
				ret.IsValid = False
				ret.ExceptionMessage = ex.ToString()
			End Try
			Return ret
		End Function
		Private Class XMLPlusValidateRequiredResult
			Private m_IsValid As Boolean
			Private m_ExceptionMessage As String
			Public Property IsValid() As Boolean
				Get
					Return m_IsValid
				End Get
				Set(value As Boolean)
					m_IsValid = value
				End Set
			End Property
			Public Property ExceptionMessage() As String
				Get
					Return m_ExceptionMessage
				End Get
				Set(value As String)
					m_ExceptionMessage = value
				End Set
			End Property
		End Class
	End Class
	<AttributeUsage(AttributeTargets.Property, Inherited:=False, AllowMultiple:=False)>
	Public Class XMLPlusElementAttribute
		Inherits XmlElementAttribute
		Public Sub New()
			MyBase.ElementName = ElementName
			Me.m_Required = False
		End Sub
		Private m_Required As Boolean
		Public Overridable Property Required() As Boolean
			Get
				Return m_Required
			End Get
			Set(value As Boolean)
				m_Required = value
			End Set
		End Property
	End Class
	<AttributeUsage(AttributeTargets.Property, Inherited:=False, AllowMultiple:=False)>
	Public Class XMLPlusAttributeAttribute
		Inherits XmlAttributeAttribute
		Public Sub New()
			MyBase.AttributeName = AttributeName
			Me.m_Required = False
		End Sub
		Private m_Required As Boolean
		Public Overridable Property Required() As Boolean
			Get
				Return m_Required
			End Get
			Set(value As Boolean)
				m_Required = value
			End Set
		End Property
	End Class
