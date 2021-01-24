    private TypeBuilder CreateClass(XmlProperty inXmlProperty = null)
        {
            if (inXmlProperty == null)
            {
                //It's root class (CONTRL; UTILMD; INVOC; ETC)
                TypeBuilder rootTypeBuilder = ModuleBuilder.DefineType(Configuration.EdiFactType,
                                                                       TypeAttributes.Public |
                                                                       TypeAttributes.Class |
                                                                       TypeAttributes.Serializable);
                RootClass = rootTypeBuilder;
                TypeController.SetClassAttributes(RootClass);
                return rootTypeBuilder;
            }
            //Nested class (Nachricht, Vorgang, etc)
            TypeBuilder typeBuilder = ModuleBuilder.DefineType(inXmlProperty.PropertyName, TypeAttributes.Public |
                                                                                           TypeAttributes.Class |
                                                                                           TypeAttributes.Serializable);
            TypeController.SetClassAttributes(typeBuilder, inXmlProperty);
            return typeBuilder;
        }
