    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Xunit.Sdk;
    
    namespace UnitTestCalculationStandards
    {
      [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
      public sealed class ExcelArrayDataAttribute : DataAttribute
      {
        string connectionTemplate =
            "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
        public ExcelArrayDataAttribute(string fileName, string queryString, bool hasHeader = true, bool returnAsArray = false)
        {
         // System.Diagnostics.Debugger.Launch();
          if (!hasHeader)
          {
            connectionTemplate = connectionTemplate.Replace("HDR=YES", "HDR=NO");
          }
          FileName = fileName;
          QueryString = queryString;
          ReturnAsArray = returnAsArray;
        }
        public string FileName { get; private set; }
        public string QueryString { get; private set; }
        private bool ReturnAsArray;
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
          if (testMethod == null)
            throw new ArgumentNullException("testMethod");
    
          ParameterInfo[] pars = testMethod.GetParameters();
    
          if (ReturnAsArray)
          {
            return DataSourceAsEnumerable(FileName, QueryString, pars.Select(par => GetEnumerableType(par.ParameterType)).ToArray());
          }
          else
          {
            return DataSource(FileName, QueryString, pars.Select(par => par.ParameterType).ToArray());
          }
        }
        static Type GetEnumerableType(Type type)
        {
          foreach (Type intType in type.GetInterfaces())
          {
            if (intType.IsGenericType
                && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
              return intType.GetGenericArguments()[0];
            }
          }
          return null;
        }
        IEnumerable<object[]> DataSourceAsEnumerable(string fileName, string selectString, Type[] parameterTypes)
        {
          string connectionString = string.Format(connectionTemplate, GetFullFilename(fileName));
          IDataAdapter adapter = new OleDbDataAdapter(selectString, connectionString);
          DataSet dataSet = new DataSet();
    
          List<object[]> rows = new List<object[]>();
          try
          {
            adapter.Fill(dataSet);
    
            foreach (DataRow row in dataSet.Tables[0].Rows)
              rows.Add(ConvertParameters(row.ItemArray, parameterTypes));
          }
          finally
          {
            IDisposable disposable = adapter as IDisposable;
            disposable.Dispose();
          }
    
          object[] columns = new object[parameterTypes.Length];
          for (int i = 0; i < parameterTypes.Length; i++)
          {
            columns[i] = rows.Select(r => r[i]).ToList();
          }
          List<object[]> rv = new List<object[]>();
          rv.Add(columns.ToArray());
    
          return rv;
        }
        IEnumerable<object[]> DataSource(string fileName, string selectString, Type[] parameterTypes)
        {
          string connectionString = string.Format(connectionTemplate, GetFullFilename(fileName));
          IDataAdapter adapter = new OleDbDataAdapter(selectString, connectionString);
          DataSet dataSet = new DataSet();
    
          try
          {
            adapter.Fill(dataSet);
    
            foreach (DataRow row in dataSet.Tables[0].Rows)
              yield return ConvertParameters(row.ItemArray, parameterTypes);
          }
          finally
          {
            IDisposable disposable = adapter as IDisposable;
            disposable.Dispose();
          }
        }
        static string GetFullFilename(string filename)
        {
          string executable = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
          return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(executable), filename));
        }
    
        static object[] ConvertParameters(object[] values, Type[] parameterTypes)
        {
          object[] result = new object[values.Length];
    
          for (int idx = 0; idx < values.Length; idx++)
            result[idx] = ConvertParameter(values[idx], idx >= parameterTypes.Length ? null : parameterTypes[idx]);
    
          return result;
        }
    
        /// <summary>
        /// Converts a parameter to its destination parameter type, if necessary.
        /// </summary>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterType">The destination parameter type (null if not known)</param>
        /// <returns>The converted parameter value</returns>
        static object ConvertParameter(object parameter, Type parameterType)
        {
          if ((parameter is double || parameter is float) &&
              (parameterType == typeof(int) || parameterType == typeof(int?)))
          {
            int intValue;
            string floatValueAsString = parameter.ToString();
    
            if (Int32.TryParse(floatValueAsString, out intValue))
              return intValue;
          }
    
          return parameter;
        }
    
    
      }
    
    }
