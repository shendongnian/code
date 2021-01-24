    public partial class ColumnTextBox : TextBox
    {
        /// <summary>
        /// The string to use to separate the columns
        /// </summary>
        public string ColumnSeparator { get; set; }
    
        public ColumnTextBox()
        {
            InitializeComponent();
            this.Multiline = true;
            this.Font = new Font(FontFamily.GenericMonospace.Name, this.Font.Size);
            this.WordWrap = false;
            this.ScrollBars = ScrollBars.Both;
            this.ColumnSeparator = " ";
        }
    
        /// <summary>
        /// Set the Text data in folumn format
        /// </summary>
        /// <param name="rowData">the data to put into the text box</param>
        public void SetColumnText(List<List<string>> rowData)
        {
            //We manually set the font to ensure it is monospaced.  Without this, the method will not format the data in nice neat columns as we want
            this.Font = new Font(FontFamily.GenericMonospace.Name, this.Font.Size);
            if (rowData == null || rowData.Count == 0)
                throw new ArgumentException("Rowdata cannot be null or empty");
    
            if (rowData[0] == null || rowData[0].Count == 0)
                throw new ArgumentException("Rowdata must contain some column data");
    
            //the string format we will use
            string format = "{0,-?}";
    
            //determine the max size of every column, and store it
            int[] colMaxSizes = CalcMaxSizes(rowData);
    
            StringBuilder sb = new StringBuilder();
    
            //Loop through every row & column to build the string piece by piece
            foreach (List<string> row in rowData)
            {
                int col = 0;
                foreach (string data in row)
                {
                    //append the data, using the format, padded to the max size.
                    //Appened column separator to end
                    sb.AppendFormat(format.Replace("?", colMaxSizes[col].ToString()), data).Append(ColumnSeparator);
                    col++;
                }
                sb.Append(Environment.NewLine);
            }
    
            //Remove last newline
            string text = sb.ToString();
            this.Text = text.Substring(0, text.Length - 1);
        }
    
        /// <summary>
        /// Calculate the max size of every column
        /// </summary>
        /// <param name="rowData">The data to search through</param>
        /// <returns>An array contain the max size/lengt of the data in each column</returns>
        private int[] CalcMaxSizes(List<List<string>> rowData)
        {
            int[] maxSizes = new int[rowData[0].Count];
            foreach (List<string> row in rowData)
            {
                int col = 0;
                foreach (string data in row)
                {
                    if (data.Length > maxSizes[col])
                        maxSizes[col] = data.Length;
                    col++;
                }
    
            }
    
            return maxSizes;
        }
    }
