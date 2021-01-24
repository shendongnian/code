    private void GenerateCustomFilePropertiesPart1Content(CustomFilePropertiesPart customFilePropertiesPart1)
        {
            Op.Properties properties2 = new Op.Properties();
            properties2.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Op.CustomDocumentProperty customDocumentProperty1 = new Op.CustomDocumentProperty() { FormatId = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}", PropertyId = 2, Name = "_MarkAsFinal" };
            Vt.VTBool vTBool1 = new Vt.VTBool();
            vTBool1.Text = "true";
            customDocumentProperty1.Append(vTBool1);
            properties2.Append(customDocumentProperty1);
            customFilePropertiesPart1.Properties = properties2;
        }
