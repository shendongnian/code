    if (!hasData)
    {
       var parameterList = new StringBuilder(null);
       var valuesList = new StringBuilder(null);
       var insertSql = new StringBuilder(null);
       parameterList.AppendFormat("Id, ");
       valuesList.Append(Id + ", ");
       foreach (var questionBase in answerList)
       {
           if (string.IsNullOrEmpty(questionBase.VariableName))
           {
               throw new ArgumentException("Question " + questionBase.QuestionNumber +
                                           " does not have a VariableName");
           }
           if (!string.IsNullOrEmpty(questionBase.VariableName) && questionBase.Answer != null)
           {
               // insert keys (variable names)
               parameterList.AppendFormat("{0}", questionBase.VariableName);
               
               if (questionBase.QuestionNumber != answerList.Last().QuestionNumber)
               {
                   parameterList.Append(", ");
               }
    
               // insert values
               valuesList.AppendFormat("{0}", questionBase.Answer);
               if (questionBase.VariableName != answerList.Last().VariableName)
                   valuesList.Append(", ");
           }
       }
    
       try
       {
           insertSql.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", tableName, parameterList, valuesList);
           Connect(ConnectionHelper.DevConnString,
               c => c.Execute(insertSql.ToString()));
           return true;
       }
       catch (Exception e)
       {
           return false;
       }
      
    }
