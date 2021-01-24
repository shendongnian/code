    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Microsoft.EntityFrameworkCore
    {
    
        public static class RDFacadeExtensions
        {
            public static RelationalDataReader ExecuteSqlQuery(this DatabaseFacade databaseFacade, string sql, params object[] parameters)
            {
                var concurrencyDetector = databaseFacade.GetService<IConcurrencyDetector>();
    
                using (concurrencyDetector.EnterCriticalSection())
                {
                    var rawSqlCommand = databaseFacade
                        .GetService<IRawSqlCommandBuilder>()
                        .Build(sql, parameters);
    
                    return rawSqlCommand
                        .RelationalCommand
                        .ExecuteReader(
                            databaseFacade.GetService<IRelationalConnection>(),
                            parameterValues: rawSqlCommand.ParameterValues);
                }
            }
        }
    }
