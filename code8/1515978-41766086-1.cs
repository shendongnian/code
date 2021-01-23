        private string FileDroppedBackground(DDQEnums.TranTypes tag, DragEventArgs e)
        {
            string[] files;
            string[] cols;
            string returnValue = string.Empty;
            SpreadsheetCheck result = new SpreadsheetCheck();
            DDQEnums.TranTypes tranType;
            List<string> fileFormats = new List<string>();
            fileFormats.Add(Constants.FileFormats.XLS);
            fileFormats.Add(Constants.FileFormats.XLSX);
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                files = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                if (files.GetLength(0) > 1)
                {
                    result.IsValid = false;
                    result.Message = "Only drop one file per input box";
                }
                else
                {
                    result = Utils.CheckIfSpreadsheetIsValidForInput(files[0], fileFormats, tag, out tranType);
                    LogEvents.UpdateProcessLogUI(Utils.BuildLogPayload(string.Format("Checking {0} Spreadsheet Column Format", tranType)));
                    Thread.Sleep(10000);
                    if (result.IsValid)
                    {
                        cols = Utils.GetSpreadsheetColumns(tranType);
                        if (cols.GetLength(0) > 0)
                        {
                            result = CheckSpreadsheetColumnFormat(files[0], cols, tranType);
                            returnValue = Path.GetFileName(files[0]);
                        }
                        else
                        {
                            result.IsValid = false;
                            result.Message = "Unable to get column definations to be used";
                        }
                    }
                }
                IsInputValid = result.IsValid;
                LogEvents.UpdateProcessLogUI(Utils.BuildLogPayload(result.Message));
                ProcessInputViewEventsPublish.SendInputValidStatus(IsInputValid, SelectedProcess, files[0]);
            }
            else
            {
                LogEvents.UpdateProcessLogUI(Utils.BuildLogPayload("Unable to get the file path for the dropped file"));
            }
            return returnValue;
        }
