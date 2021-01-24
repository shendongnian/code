        class SqlInterfaceViewModel : ViewModelBase
    {
        private IDBQuery connection;
        private string sql;
        private DataTable resultData;
        private DataTable outputData;
        private string resultStatus;
        private bool queryRunning;
        private string elapsedTime;
        private int sqlCount;
        private string selectedText;
        private bool cancelSql;
        public ICommand CommandExecute { get { return new ButtonViewModel(new ButtonModel(new Action(executeSql))).ClickCommand; } }
        public ICommand CommandCancel { get { return new ButtonViewModel(new ButtonModel(new Action(Cancel))).ClickCommand; } }
        public ICommand CommandClear { get { return new ButtonViewModel(new ButtonModel(new Action(Clear))).ClickCommand; } }
        public event PropertyChangedEventHandler PropertyChanged;
        public SqlInterfaceViewModel(IDBQuery connection){
            this.connection = connection;
            outputData = new DataTable();
            outputData.Columns.Add("DateTime", typeof(string));
            outputData.Columns.Add("Action", typeof(string));
            outputData.Columns.Add("Message", typeof(string));
            outputData.Columns.Add("Duration", typeof(string));
            cancelSql = false;
            OutputData.RowChanged += new DataRowChangeEventHandler(Row_Changed);
        }
        #region public properties
        public bool QueryRunning
        {
            get { return queryRunning; }
            set
            {
                if (value != this.queryRunning)
                {
                    queryRunning = value;
                    OnPropertyChanged("QueryRunning");
                }
            }
        }
        public string Sql
        {
            get { return sql; }
            set
            {
                if (sql != value)
                    sql = value;
                OnPropertyChanged("Sql");
            }
        }
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                if (selectedText != value)
                    selectedText = value;
            }
        }
        public DataTable ResultData
        {
            get { return resultData; }
            set
            {
                if (resultData != value)
                    resultData = value;
                OnPropertyChanged("ResultData");
            }
        }
        public DataTable OutputData
        {
            get { return outputData; }
            set
            {
                if (outputData != value)
                    outputData = value;
                OnPropertyChanged("OutputData");
            }
        }
        public string ResultStatus
        {
            get { return resultStatus; }
            set
            {
                if (resultStatus != value)
                    resultStatus = value;
                OnPropertyChanged("ResultStatus");
            }
        }
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            OnPropertyChanged("OutputData");
        }
        #endregion
        private List<string> sqlList()
        {
            List<string> SqlList;
            if (string.IsNullOrEmpty(selectedText))
                SqlList = sql.Split(';').ToList();
            else
                SqlList = selectedText.Split(';').ToList();
            return SqlList;
        }
        public async Task FormatOutput(string statement, string dateTime, string error)
        {
          statement = statement.Trim().Trim(new char[] { '\r', '\n' });
            string text = string.Empty;
                if (string.IsNullOrEmpty(statement) == false)
            {
                string substring = statement.ToUpper().Substring(0, statement.IndexOf(' '));
                if (string.IsNullOrEmpty(error) != true)
                    text = error;
                else
                    switch (substring)
                    {
                        case ("SELECT"):
                            text = ResultData.Rows.Count.ToString() + " rows selected";
                            break;
                        case ("UPDATE"):
                            text = sqlCount + " rows updated";
                            break;
                        case ("INSERT"):
                            text = sqlCount + " rows inserted";
                            break;
                        case ("DELETE"):
                            text = sqlCount + " rows deleted";
                            break;
                        case ("DROP"):
                            text = "Table dropped";
                            break;
                        case ("CREATE"):
                            text = "Table created";
                            break;
                    }
            }
            await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                OutputData.Rows.Add(new object[] { dateTime, statement, text, elapsedTime });}));
        }
        public async void executeSql()
        {
            QueryRunning = true;
            foreach (string statement in sqlList())
            {
                if (cancelSql == true) { cancelSql = false; break; }
                string error = string.Empty;
                System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
                DateTime dateTime = DateTime.Now;
                if (string.IsNullOrEmpty(statement) == false)
                {
                    try
                    {
                        if (statement.ToUpper().Substring(0, statement.IndexOf(' ')).Contains("SELECT"))
                            ResultData = await connection.GetResultSetTask(statement);
                        else
                            sqlCount = await connection.ExecuteUpdate(statement);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        sw.Stop();
                        elapsedTime = sw.Elapsed.ToString(@"hh\:mm\:ss\.ffff");
                        await FormatOutput(statement, dateTime.ToString(), error);
                        cancelSql = false;
                    }
                }
            }
            QueryRunning = false;
        }
        public void Cancel()
        {
            connection.cancelQuery();
            cancelSql = true;
        }
        public void Clear()
        { Sql = string.Empty; }
    }
