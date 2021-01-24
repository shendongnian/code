    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strConnection))
    {
      bulkCopy.ColumnMappings.Add("Student", "Student");
      bulkCopy.ColumnMappings.Add("Grade", "Grade"); 
      bulkCopy.DestinationTableName = "Student";
      bulkCopy.WriteToServer(dtStudent);
    }
