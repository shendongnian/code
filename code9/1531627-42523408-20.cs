    public class CustomXsdCodeGenerator : CustomXsdCodeGeneratorBase
    {
        readonly bool promoteToNullable;
        public CustomXsdCodeGenerator(string Namespace, bool promoteToNullable) : base(Namespace)
        {
            this.promoteToNullable = promoteToNullable;
        }
        protected override void ModifyGeneratedCodeTypeDeclaration(CodeTypeDeclaration codeType, CodeNamespace codeNamespace)
        {
            RemoveSpecifiedProperties(codeNamespace, promoteToNullable);
            base.ModifyGeneratedCodeTypeDeclaration(codeType, codeNamespace);
        }
        private static void RemoveSpecifiedProperties(CodeNamespace codeNamespace, bool promoteToNullable)
        {
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                RemoveSpecifiedProperties(codeType, codeNamespace, promoteToNullable);
            }
        }
        private static void RemoveSpecifiedProperties(CodeTypeDeclaration codeType, CodeNamespace codeNamespace, bool promoteToNullable)
        {
            var toRemove = new List<CodeTypeMember>();
            foreach (var property in codeType.Members.OfType<CodeMemberProperty>())
            {
                CodeMemberField backingField;
                CodeMemberProperty specifiedProperty;
                if (!property.TryGetBackingFieldAndSpecifiedProperty(codeType, out backingField, out specifiedProperty))
                    continue;
                var specifiedField = specifiedProperty.GetBackingField(codeType);
                if (specifiedField == null)
                    continue;
                toRemove.Add(specifiedProperty);
                toRemove.Add(specifiedField);
                if (promoteToNullable)
                {
                    // Do not do this for attributes
                    if (property.CustomAttributes.Cast<CodeAttributeDeclaration>().Any(a => a.AttributeType.BaseType == typeof(System.Xml.Serialization.XmlAttributeAttribute).FullName))
                        continue;
                    var typeRef = property.Type;
                    if (typeRef.ArrayRank > 0)
                        // An array - not a reference type.
                        continue;
                    // OK, two possibilities here:
                    // 1) The property might reference some system type such as DateTime or decimal
                    // 2) The property might reference some type being defined such as an enum or struct.
                    var type = Type.GetType(typeRef.BaseType);
                    if (type != null)
                    {
                        if (!type.IsClass)
                        {
                            if (type == typeof(Nullable<>))
                                // Already nullable
                                continue;
                            else if (!type.IsGenericTypeDefinition && (type.IsValueType || type.IsEnum) && Nullable.GetUnderlyingType(type) == null)
                            {
                                var nullableType = typeof(Nullable<>).MakeGenericType(type);
                                var newRefType = new CodeTypeReference(nullableType);
                                property.Type = newRefType;
                                backingField.Type = newRefType;
                            }
                        }
                    }
                    else
                    {
                        var generatedType = codeNamespace.FindCodeType(typeRef);
                        if (generatedType != null)
                        {
                            if (generatedType.IsStruct || generatedType.IsEnum)
                            {
                                var newRefType = new CodeTypeReference(typeof(Nullable<>).FullName, typeRef);
                                property.Type = newRefType;
                                backingField.Type = newRefType;
                            }
                        }
                    }
                }
            }
            foreach (var member in toRemove)
            {
                codeType.Members.Remove(member);
            }
        }
    }
    public static class CodeNamespaceExtensions
    {
        public static CodeTypeDeclaration FindCodeType(this CodeNamespace codeNamespace, CodeTypeReference reference)
        {
            if (codeNamespace == null)
                throw new ArgumentNullException();
            if (reference == null)
                return null;
            CodeTypeDeclaration foundType = null;
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                if (codeType.Name == reference.BaseType)
                {
                    if (foundType == null)
                        foundType = codeType;
                    else if (foundType != codeType)
                    {
                        foundType = null;
                        break;
                    }
                }
            }
            return foundType;
        }
    }
    public static class CodeMemberPropertyExtensions
    {
        public static bool TryGetBackingFieldAndSpecifiedProperty(this CodeMemberProperty property, CodeTypeDeclaration codeType,
            out CodeMemberField backingField, out CodeMemberProperty specifiedProperty)
        {
            if (property == null)
            {
                backingField = null;
                specifiedProperty = null;
                return false;
            }
            if ((backingField = property.GetBackingField(codeType)) == null)
            {
                specifiedProperty = null;
                return false;
            }
            specifiedProperty = null;
            var specifiedName = property.Name + "Specified";
            foreach (var p in codeType.Members.OfType<CodeMemberProperty>())
            {
                if (p.Name == specifiedName)
                {
                    // Make sure the property is marked as XmlIgnore (there might be a legitimate, serializable property
                    // named xxxSpecified).
                    if (!p.CustomAttributes.Cast<CodeAttributeDeclaration>().Any(a => a.AttributeType.BaseType == typeof(System.Xml.Serialization.XmlIgnoreAttribute).FullName))
                        continue;
                    if (specifiedProperty == null)
                        specifiedProperty = p;
                    else if (specifiedProperty != p)
                    {
                        specifiedProperty = null;
                        break;
                    }
                }
            }
            if (specifiedProperty == null)
                return false;
            if (specifiedProperty.GetBackingField(codeType) == null)
                return false;
            return true;
        }
        public static CodeMemberField GetBackingField(this CodeMemberProperty property, CodeTypeDeclaration codeType)
        {
            if (property == null)
                return null;
            CodeMemberField returnedField = null;
            foreach (var statement in property.GetStatements.OfType<CodeMethodReturnStatement>())
            {
                var expression = statement.Expression as CodeFieldReferenceExpression;
                if (expression == null)
                    return null;
                if (!(expression.TargetObject is CodeThisReferenceExpression))
                    return null;
                var fieldName = expression.FieldName;
                foreach (var field in codeType.Members.OfType<CodeMemberField>())
                {
                    if (field.Name == fieldName)
                    {
                        if (returnedField == null)
                            returnedField = field;
                        else if (returnedField != field)
                            return null;
                    }
                }
            }
            return returnedField;
        }
    }
    public abstract class CustomXsdCodeGeneratorBase
    {
        // This base class adapted from http://mikehadlow.blogspot.com/2007/01/writing-your-own-xsdexe.html
        readonly string Namespace;
        public CustomXsdCodeGeneratorBase(string Namespace)
        {
            this.Namespace = Namespace;
        }
        public void XsdToClassTest(IEnumerable<string> xsds, TextWriter codeWriter)
        {
            XsdToClassTest(xsds.Select(xsd => (Func<TextReader>)(() => new StringReader(xsd))), codeWriter);
        }
        public void XsdToClassTest(IEnumerable<Func<TextReader>> xsds, TextWriter codeWriter)
        {
            var schemas = new XmlSchemas();
            foreach (var getReader in xsds)
            {
                using (var reader = getReader())
                {
                    var xsd = XmlSchema.Read(reader, null);
                    schemas.Add(xsd);
                }
            }
            schemas.Compile(null, true);
            var schemaImporter = new XmlSchemaImporter(schemas);
            var maps = new List<XmlTypeMapping>();
            foreach (XmlSchema xsd in schemas)
            {
                foreach (XmlSchemaType schemaType in xsd.SchemaTypes.Values)
                {
                    maps.Add(schemaImporter.ImportSchemaType(schemaType.QualifiedName));
                }
                foreach (XmlSchemaElement schemaElement in xsd.Elements.Values)
                {
                    maps.Add(schemaImporter.ImportTypeMapping(schemaElement.QualifiedName));
                }
            }
            // create the codedom
            var codeNamespace = new CodeNamespace(this.Namespace);
            var codeExporter = new XmlCodeExporter(codeNamespace);
            foreach (XmlTypeMapping map in maps)
            {
                codeExporter.ExportTypeMapping(map);
            }
            ModifyGeneratedNamespace(codeNamespace);
            // Check for invalid characters in identifiers
            CodeGenerator.ValidateIdentifiers(codeNamespace);
            // output the C# code
            var codeProvider = new CSharpCodeProvider();
            codeProvider.GenerateCodeFromNamespace(codeNamespace, codeWriter, new CodeGeneratorOptions());
        }
        protected virtual void ModifyGeneratedNamespace(CodeNamespace codeNamespace)
        {
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                ModifyGeneratedCodeTypeDeclaration(codeType, codeNamespace);
            }
        }
        protected virtual void ModifyGeneratedCodeTypeDeclaration(CodeTypeDeclaration codeType, CodeNamespace codeNamespace)
        {
        }
    }
