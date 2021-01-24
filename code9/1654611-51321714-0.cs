    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore.Update;
    /// <summary>
    /// SqlServerUpdateSqlGenerator with Insert_Identity.
    /// </summary>
    public class SqlServerUpdateSqlGeneratorInsertIdentity : SqlServerUpdateSqlGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerUpdateSqlGeneratorInsertIdentity"/> class.
        /// </summary>
        /// <param name="dependencies">The dependencies.</param>
        public SqlServerUpdateSqlGeneratorInsertIdentity(UpdateSqlGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }
        /// <inheritdoc/>
        public override ResultSetMapping AppendBulkInsertOperation(
            StringBuilder commandStringBuilder,
            IReadOnlyList<ModificationCommand> modificationCommands,
            int commandPosition)
        {
            var columns = modificationCommands[0].ColumnModifications.Where(o => o.IsWrite).Select(o => o.ColumnName)
                .ToList();
            var schema = modificationCommands[0].Schema;
            var table = modificationCommands[0].TableName;
            GenerateIdentityInsert(commandStringBuilder, table, schema, columns, on: true);
            var result = base.AppendBulkInsertOperation(commandStringBuilder, modificationCommands, commandPosition);
            GenerateIdentityInsert(commandStringBuilder, table, schema, columns, on: false);
            return result;
        }
        private void GenerateIdentityInsert(
            StringBuilder builder,
            string table,
            string schema,
            IEnumerable<string> columns,
            bool on)
        {
            var stringTypeMapping = Dependencies.TypeMappingSource.GetMapping(typeof(string));
            builder.Append("IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE").Append(" [name] IN (")
                .Append(string.Join(", ", columns.Select(stringTypeMapping.GenerateSqlLiteral)))
                .Append(") AND [object_id] = OBJECT_ID(").Append(
                    stringTypeMapping.GenerateSqlLiteral(
                        Dependencies.SqlGenerationHelper.DelimitIdentifier(table, schema))).AppendLine("))");
            builder.Append("SET IDENTITY_INSERT ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(table, schema)).Append(on ? " ON" : " OFF")
                .AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator);
        }
    }
