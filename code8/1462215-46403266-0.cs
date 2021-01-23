    public void CreateValidator(Worksheet ws, string dataContainingSheet)
            {
                /***  DATA VALIDATION CODE ***/
                DataValidations dataValidations = new DataValidations();
                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue> { InnerText = "A1:A1048576" }
                };
    
                dataValidation.Append(
                    //new Formula1 { Text = "\"FirstChoice,SecondChoice,ThirdChoice\"" }
                    new Formula1(string.Format("'{0}'!$A:$A", dataContainingSheet))
                    );
                dataValidations.Append(dataValidation);
    
                var wsp = ws.WorksheetPart;
                wsp.Worksheet.AppendChild(dataValidations);
            }
