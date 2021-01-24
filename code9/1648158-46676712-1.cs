    public string LabelConformidadValidadion
            {
                get { return GetValue<string>(LabelConformidadValidadionProperty); }
                set { SetValue(LabelConformidadValidadionProperty,value); }
            }
    
            public static readonly PropertyData LabelConformidadValidadionProperty = RegisterProperty("LabelConformidadValidadion", typeof(string), null);
...
    protected override void ValidateFields(List<IFieldValidationResult> validationResults)
            {
                if (Peso!=null && !Peso.Peso_Caliente.HasValue)
                    validationResults.Add(FieldValidationResult.CreateErrorWithTag(Peso_CalienteProperty,"No se ha capturado el peso", "Captura_PesoCalienteCanExecute"));
                if (Peso!=null && !Peso.IC.HasValue)
                    validationResults.Add(FieldValidationResult.CreateError(LabelConformidadValidadionProperty, "No se ha capturado el indicador IC"));
            }
