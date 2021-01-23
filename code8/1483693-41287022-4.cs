        private static void FetchMotherboardIdInternal()
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
                scope.Connect();
                using (ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions()))
                {
                    object motherboardIDObj = wmiClass["SerialNumber"];
                    if (motherboardIDObj != null)
                    {
                        string motherboardID = motherboardIDObj.ToString().Trim();
                        Trace.WriteLine("MotherboardID = " + motherboardID);
                        if (IsValidMotherBoardID(motherboardID))
                        {
                            _motherboardID = motherboardID;
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("Failed to read MotherbaordID\r\n" + ex.Message);
            }
        }
        public static bool IsValidMotherBoardID(string value)
        {
            if (value == null)
                return false;
            string motherboardID = value.Trim();
            return !(   motherboardID.Replace(".", "").Replace(" ", "").Replace("\t", "").Trim().Length < 5 ||
                       motherboardID.ToUpper().Contains("BASE") ||
                       motherboardID.Contains("2345") ||
                       motherboardID.ToUpper().StartsWith("TO BE") ||
                       motherboardID.ToUpper().StartsWith("NONE") ||
                       motherboardID.ToUpper().StartsWith("N/A") ||
                       motherboardID.ToUpper().Contains("SERIAL") ||
                       motherboardID.ToUpper().Contains("OEM") ||
                       motherboardID.ToUpper().Contains("AAAAA") ||
                       motherboardID.ToUpper().Contains("ABCDE") ||
                       motherboardID.ToUpper().Contains("XXXXX") ||
                       motherboardID.ToUpper().Contains("NOT") ||
                       motherboardID.ToUpper().StartsWith("00000")
                    );
        }
