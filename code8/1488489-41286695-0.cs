    [ExportCodeAnalysisRule(DataTypesOnBothSidesOfEqualityRule.RuleId,
        DataTypesOnBothSidesOfEqualityRule.RuleDisplayName,
        Description = DataTypesOnBothSidesOfEqualityRule.RuleDisplayName,
        Category = Constants.Performance,
        RuleScope = SqlRuleScope.Element)]
    public sealed class DataTypesOnBothSidesOfEqualityRule : SqlCodeAnalysisRule
    {
        public const string RuleId = Constants.RuleNameSpace + "SRP0016";
        public const string RuleDisplayName = "Data types on both sides of an equality check should be the same in the where clause. (Sargeable)";
        public const string Message = "{0} {1} data types on both sides of an equality do not match in the where clause.";
        private static StringComparer _comparer = StringComparer.InvariantCultureIgnoreCase;
        private readonly FunctionChain functionChain = new FunctionChain();
        #region built in function data types
        private static IDictionary<string, string> _functions = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            /*Date and Time Data Types and Functions (Transact-SQL)*/
            { "SYSDATETIME", "datetime2" },
            { "SYSDATETIMEOFFSET", "datetimeoffset" },
            { "SYSUTCDATETIME", "datetime2" },
            { "CURRENT_TIMESTAMP", "datetime" },
            { "GETDATE", "datetime" },
            { "GETUTCDATE", "datetime" },
            { "DATENAME", "nvarchar" },
            { "DATEPART", "int" },
            { "DAY", "int" },
            { "MONTH", "int" },
            { "YEAR", "int" },
            { "DATEFROMPARTS", "date" },
            { "DATETIME2FROMPARTS", "datetime2" },
            { "DATETIMEFROMPARTS", "datetime" },
            { "DATETIMEOFFSETFROMPARTS", "datetimeoffset" },
            { "SMALLDATETIMEFROMPARTS", "smalldatetime" },
            { "TIMEFROMPARTS", "time" },
            { "DATEDIFF", "int" },
            { "DATEDIFF_BIG", "bigint" },
            { "ISDATE", "int" },
            /* Mathematical Functions (Transact-SQL)*/
            { "ACOS", "float" },
            { "ASIN", "float" },
            { "ATAN", "float" },
            { "ATN2", "float" },
            { "COS", "float" },
            { "COT", "float" },
            { "EXP", "float" },
            { "LOG", "float" },
            { "LOG10", "float" },
            { "PI", "float" },
            { "POWER", "float" },
            { "RAND", "float" },
            //{ "ROUND", "" }, completely unable to figure out how to map these. leaving commented here to mark that in case someone else figures it out
            //{ "SIGN", "" },
            { "SIN", "float" },
            { "SQRT", "float" },
            { "SQUARE", "float" },
            { "TAN", "float" },
            /*String Functions (Transact-SQL)*/
            { "ASCII", "int" },
            { "CHAR", "char" },
            { "DIFFERENCE", "int" },
            { "FORMAT", "nvarchar" },
            { "QUOTENAME", "nvarchar" },
            { "SOUNDEX", "varchar" },
            { "SPACE", "varchar" },
            { "STR", "varchar" },
            { "STRING_ESCAPE", "nvarchar" },
            { "UNICODE", "int" },
            /* System Functions (Transact-SQL)*/
            { "HOST_ID", "char" },
            { "HOST_NAME", "nvarchar" },
            { "ISNUMERIC", "int" },
            { "NEWID", "uniqueidentifier" },
            { "NEWSEQUENTIALID", "uniqueidentifier" },
            { "ROWCOUNT_BIG", "bigint" },
            { "SESSION_CONTEXT", "sql_variant" },
            { "SESSION_ID", "nvarchar" },
            { "XACT_STATE", "smallint" },
            /*Metadata Functions (Transact-SQL)*/
            { "APP_NAME", "nvarchar" },
            { "APPLOCK_MODE", "nvarchar" },
            { "APPLOCK_TEST", "smallint" },
            { "ASSEMBLYPROPERTY", "sql_variant" },
            { "COL_LENGTH", "smallint" },
            { "COL_NAME", "nvarchar" },
            { "COLUMNPROPERTY", "int" },
            { "DATABASEPROPERTYEX", "sql_variant" },
            { "DB_ID", "int" },
            { "DB_NAME", "nvarchar" },
            { "FILE_ID", "smallint" },
            { "FILE_IDEX", "int" },
            { "FILE_NAME", "nvarchar" },
            { "FILEGROUP_ID", "int" },
            { "FILEGROUP_NAME", "nvarchar" },
            { "FILEGROUPPROPERTY", "int" },
            { "FILEPROPERTY", "int" },
            { "FULLTEXTCATALOGPROPERTY", "int" },
            { "FULLTEXTSERVICEPROPERTY", "int" },
            { "INDEX_COL", "nvarchar" },
            { "INDEXKEY_PROPERTY", "int" },
            { "INDEXPROPERTY", "int" },
            { "OBJECT_DEFINITION", "nvarchar" },
            { "OBJECT_ID", "int" },
            { "OBJECT_NAME", "sysname" },
            { "OBJECT_SCHEMA_NAME", "sysname" },
            { "OBJECTPROPERTY", "int" },
            { "OBJECTPROPERTYEX", "sql_variant" },
            { "ORIGINAL_DB_NAME", "nvarchar" },
            { "PARSENAME", "nchar" },
            { "SCHEMA_ID", "int" },
            { "SCHEMA_NAME", "sysname" },
            { "SCOPE_IDENTITY", "numeric" },
            { "SERVERPROPERTY", "sql_variant" },
            { "STATS_DATE", "datetime" },
            { "TYPE_ID", "int" },
            { "TYPE_NAME", "sysname" },
            { "TYPEPROPERTY", "int" },
            /*Security Functions (Transact-SQL)*/
            { "CERTENCODED", "varbinary" },
            { "CERTPRIVATEKEY", "varbinary" },
            { "CURRENT_USER", "sysname" },
            { "DATABASE_PRINCIPAL_ID", "int" },
            { "HAS_PERMS_BY_NAME", "int" },
            { "IS_MEMBER", "int" },
            { "IS_ROLEMEMBER", "int" },
            { "IS_SRVROLEMEMBER", "int" },
            { "ORIGINAL_LOGIN", "sysname" },
            { "PERMISSIONS", "int" },
            { "PWDCOMPARE", "int" },
            { "PWDENCRYPT", "varbinary" },
            { "SESSION_USER", "nvarchar" },
            { "SUSER_ID", "int" },
            { "SUSER_SID", "varbinary" },
            { "SUSER_SNAME", "nvarchar" },
            { "SYSTEM_USER", "nchar" },
            { "SUSER_NAME", "nvarchar" },
            { "USER_ID", "int" },
            { "USER_NAME", "nvarchar" }
        };
        #endregion
        public DataTypesOnBothSidesOfEqualityRule()
        {
            SupportedElementTypes = new[] { ModelSchema.Procedure, ModelSchema.View, ModelSchema.ScalarFunction, ModelSchema.TableValuedFunction };
        }
        public override IList<SqlRuleProblem> Analyze(SqlRuleExecutionContext ruleExecutionContext)
        {
            var problems = new List<SqlRuleProblem>();
            var sqlObj = ruleExecutionContext.ModelElement; //proc / view / function
            try
            {
                if (sqlObj != null)
                {
                    var fragment = ruleExecutionContext.ScriptFragment;
                    //get the combined parameters and declare variables into one searchable list
                    var variablesVisitor = new VariablesVisitor();
                    fragment.AcceptChildren(variablesVisitor);
                    var variables = variablesVisitor.GetVariables();
                    var selectStatementVisitor = new SelectStatementVisitor();
                    fragment.Accept(selectStatementVisitor);
                    foreach (var select in selectStatementVisitor.Statements)
                    {
                        var query = select.QueryExpression as QuerySpecification;
                        if (query != null && query.WhereClause != null)
                        {
                            var booleanComparisonVisitor = new BooleanComparisonVisitor();
                            query.WhereClause.Accept(booleanComparisonVisitor);
                            foreach (var comparison in booleanComparisonVisitor.Statements)
                            {
                                var datatype1 = GetDataType(sqlObj, query, comparison.FirstExpression, variables);
                                if (string.IsNullOrEmpty(datatype1)) { continue; }
                                var datatype2 = GetDataType(sqlObj, query, comparison.SecondExpression, variables);
                                if (string.IsNullOrEmpty(datatype2)) { continue; }
                                //when checking the numeric literal I am not sure if it is a bit or tinyint.
                                if ((_comparer.Equals(datatype1, "bit") && _comparer.Equals(datatype2, "tinyint")) || (_comparer.Equals(datatype1, "tinyint") && _comparer.Equals(datatype2, "bit"))) { continue; }
                                if (!_comparer.Equals(datatype1, datatype2))
                                {
                                    string msg = string.Format(Message, sqlObj.ObjectType.Name, RuleUtils.GetElementName(ruleExecutionContext, sqlObj));
                                    problems.Add(new SqlRuleProblem(msg, sqlObj, comparison));
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                //TODO: PROPERLY LOG THIS ERROR
                Debug.WriteLine(ex.ToString());
                //throw;
            }
            return problems;
        }
        private string GetDataType(TSqlObject sqlObj, QuerySpecification query, ScalarExpression expression, IList<VariableView> variables)
        {
            if (expression is ColumnReferenceExpression)
            {
                return GetColumnDataType(sqlObj, query, expression);
            }
            else if (expression is StringLiteral)
            {
                var stringLiteral = expression as StringLiteral;
                if (stringLiteral.IsNational)
                {
                    return "nvarchar";
                }
                else
                {
                    return "varchar";
                }
            }
            else if (expression is IntegerLiteral)
            {
                long val = long.Parse(((IntegerLiteral)expression).Value);
                if (val >= 0 && val <= 255) // to bit or not to bit? NFC.
                {
                    return "tinyint";
                }
                else if (val >= -32768 && val <= 32768)
                {
                    return "smallint";
                }
                else if (val >= -2147483648 && val <= 2147483648)
                {
                    return "int";
                }
                else if (val >= -9223372036854775808 && val <= 9223372036854775807)
                {
                    return "bigint";
                }
                //technically this may not be accurate. as sql sever will interpret literal ints as different types 
                //depending upon how large they are. smallint, tinyint, etc... Unless I mimic their same value behavior.
                return "int";
            }
            else if (expression is CastCall)
            {
                var castCall = expression as CastCall;
                return castCall.DataType.Name.Identifiers.First().Value;
            }
            else if (expression is VariableReference)
            {
                var variable = variables.FirstOrDefault(v => _comparer.Equals(v.Name, ((VariableReference)expression).Name));
                if (variable != null)
                {
                    return variable.DataType;
                }
            }
            else if (expression is FunctionCall)
            {
                //TIM C: sigh, this does not work for all functions. the api does not allow for me to look up built in functions. nor does it allow me to get the 
                //data types of parameters, so I am not able to type ALL functions like DATEADD, the parameter could be a column, string literal, variable, function etc...
                var function = expression as FunctionCall;
                if (_functions.ContainsKey(function.FunctionName.Value))
                {
                    return _functions[function.FunctionName.Value];
                }
            }
            else if (expression is BinaryExpression)
            {
                var binaryExpression = expression as BinaryExpression;
                var datatype1 = GetDataType(sqlObj, query, binaryExpression.FirstExpression, variables);
                if (datatype1 != null) { return datatype1; }
                return GetDataType(sqlObj, query, binaryExpression.SecondExpression, variables);
            }
            else if (expression is ScalarSubquery)
            {
                var scalarQuery = ((ScalarSubquery)expression).QueryExpression as QuerySpecification;
                var selectElement = scalarQuery.SelectElements.First();
                return GetDataType(sqlObj, scalarQuery, ((SelectScalarExpression)selectElement).Expression, variables);
            }
            else
            {
                Debug.WriteLine("Unknown expression");
            }
            return null;
        }
        private string GetColumnDataType(TSqlObject sqlObj, QuerySpecification query, ScalarExpression expression)
        {
            var column = expression as ColumnReferenceExpression;
            var tables = new List<NamedTableReference>();
            var namedTableVisitor = new NamedTableReferenceVisitor();
            query.FromClause.AcceptChildren(namedTableVisitor);
            if (column.MultiPartIdentifier.Identifiers.Count == 2)
            {
                tables.AddRange(namedTableVisitor.Statements.Where(x => x.Alias?.Value == column.MultiPartIdentifier.Identifiers[0].Value));
            }
            else
            {
                //they did NOT use a two part name, so logic dictates that this column SHOULD only appear once in the list of tables, but we will have to search all of the tables.
                tables.AddRange(namedTableVisitor.Statements);
            }
            var referencedTables = sqlObj.GetReferenced().Where(x => x.ObjectType == Table.TypeClass && tables.Any(t => x.Name.CompareTo(t.SchemaObject.Identifiers)));
            foreach (var referencedTable in referencedTables)
            {
                string fullColumnName = referencedTable.Name.ToString() + ".[" + column.MultiPartIdentifier.Identifiers.Last().Value + "]";
                var retColumn = referencedTable.GetReferencedRelationshipInstances(Table.Columns).FirstOrDefault(p => _comparer.Equals(p.ObjectName.ToString(), fullColumnName));
                if (retColumn != null)
                {
                    var dataType = retColumn.Object.GetReferenced(Column.DataType)
                                .FirstOrDefault();
                    return dataType.Name.Parts.First();
                }
            }
            return null;
        }
    }
