    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace CsvReaderExample
    {
        public class CsvReader
            : BackgroundWorker
        {
            string[] m_lines;
            public DataTable DataTable { get; private set; }
            public CsvReader(string[] lines)
            {
                m_lines = lines;
                WorkerReportsProgress      = true;
                WorkerSupportsCancellation = true;
            }
            public DataTable RunWorker()
            {
                return DataTable = ParseCsvLines();
            }
            protected override void OnDoWork(DoWorkEventArgs e)
            {
                base.OnDoWork(e);
                e.Result = DataTable = ParseCsvLines();
            }
            private DataTable ParseCsvLines()
            {
                if (m_lines.Length == 0)
                    return null;
                var table       = new DataTable();
                var columns     = table.Columns;
                var columnNames = GetRowValues(m_lines[0]);
                foreach (var columnName in columnNames)
                {
                    var name   = columnName;
                    int number = 2;
                    while (columns.Contains(name))
                        name += " " + number++;
                    columns.Add(name);
                }
                var rows = table.Rows;
                for (int index = 1, linesCount = m_lines.Length; index < linesCount; index++)
                {
                    if (CancellationPending)
                        return null;
                    var line       = m_lines[index];
                    var values     = GetRowValues(line);
                    int valueCount = values.Count;
                    if (valueCount > columns.Count)
                    {
                        int columnNumber = columns.Count;
                        while (columns.Contains(columnNumber.ToString()))
                            columnNumber++;
                        columns.Add(columnNumber.ToString());
                    }
                    rows.Add(values.ToArray());
                    if (WorkerReportsProgress)
                        ReportProgress(100 * index / linesCount);
                }
                return table;
            }
            const char COMMA        = ',',
                       DOUBLE_QUOTE = '"',
                       VERTICAL_BAR = '|';
            private List<string> GetRowValues(string line)
            {
                var builder        = new StringBuilder();
                var values         = new List<string>();
                var inDoubleQuotes = false;
                var maxIndex       = line.Length - 1;
                for (int index = 0; index <= maxIndex; index++)
                {
                    char c = line[index];
                    if (c == DOUBLE_QUOTE)
                    {
                        if (index == 0)
                        {
                            inDoubleQuotes = true;
                            continue;
                        }
                        if (index < maxIndex)
                        {
                            var nextIndex = index + 1;
                            if (nextIndex < maxIndex)
                            {
                                if (line[nextIndex] == DOUBLE_QUOTE)
                                {
                                    index++;
                                    if (inDoubleQuotes)
                                        builder.Append(DOUBLE_QUOTE);
                                    continue;
                                }
                            }
                        }
                        inDoubleQuotes = !inDoubleQuotes;
                        continue;
                    }
                    if (c == COMMA)
                    {
                        if (inDoubleQuotes)
                        {
                            builder.Append(c);
                            continue;
                        }
                        values.Add(builder.ToString());
                        builder = new StringBuilder();
                        continue;
                    }
                    builder.Append(c);
                }
                values.Add(builder.ToString());
                return values;
            }
            #region Sanitise cells with new line characters
            public static void SanitiseCellsWithNewLineCharacters(string fileName)
            {
                var text = File.ReadAllText(fileName, Encoding.Default);
                text     = text.Replace("\r\n", "\n");
                text     = text.Replace("\r",   "\n");
                using (var writer = File.CreateText(fileName))
                {
                    var inDoubleQuotes = false;
                    foreach (char c in text)
                    {
                        if (c == '\n' && inDoubleQuotes)
                        {
                            writer.Write(VERTICAL_BAR);
                            continue;
                        }
                        if (c == DOUBLE_QUOTE)
                        {
                            if (inDoubleQuotes)
                                inDoubleQuotes = false;
                            else
                                inDoubleQuotes = true;
                        }
                        writer.Write(c);
                    }
                }
            }
            #endregion
        }
    }
