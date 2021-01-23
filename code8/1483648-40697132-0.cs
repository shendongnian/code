        public void AutoOpen()
        {
            var conversionConfig = GetParameterConversionConfig();
            ExcelRegistration.GetExcelFunctions()
                             .ProcessParameterConversions(conversionConfig)
                             .RegisterFunctions();
        }
