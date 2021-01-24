        if (Path.GetExtension(filePath).Equals(".xls"))//for 97-03 Excel file
        {
            sbConnection.Provider = "Microsoft.Jet.OLEDB.4.0";
            strExtendedProperties = "Excel 8.0;HDR=No;IMEX=1";//HDR=ColumnHeader,IMEX=InterMixed
        }
        else if (Path.GetExtension(filePath).Equals(".xlsx"))  //for 2007 Excel file
        {
            sbConnection.Provider = "Microsoft.ACE.OLEDB.12.0";
            strExtendedProperties = "Excel 12.0;HDR=No;IMEX=1";
        }
        else
            throw new MyException("Ошибка чтения Excel файла. Необходимо сконвертировать Ваш файл в \".xlsx\" или \".xls\" формат.");
