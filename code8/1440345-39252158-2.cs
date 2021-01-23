    /// <summary>
    /// This class represents the file/directory information received via FTP.ListDirectoryDetails
    /// </summary>
    public class ListDirectoryDetailsOutput
    {
        public bool IsDirectory { get; set; }
        public bool IsFile {
            get { return !IsDirectory; } 
        }
        //Owner permissions
        public bool OwnerRead { get; set; }
        public bool OwnerWrite { get; set; }
        public bool OwnerExecute { get; set; }
        //Group permissions
        public bool GroupRead { get; set; }
        public bool GroupWrite { get; set; }
        public bool GroupExecute { get; set; }
        //Other permissions
        public bool OtherRead { get; set; }
        public bool OtherWrite { get; set; }
        public bool OtherExecute { get; set; }
        public int NumberOfLinks { get; set; }
        public int Size { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public bool ParsingError { get; set; }
        public Exception ParsingException { get; set; }
        /// <summary>
        /// Parses the FTP response for ListDirectoryDetails into the Output object
        /// An example input of a file called test1.xml:
        /// -rw-r--r-- 1 ftp ftp            960 Aug 31 09:09 test1.xml
        /// </summary>
        /// <param name="ftpResponseLine"></param>
        public ListDirectoryDetailsOutput(string ftpResponseLine)
        {
            try
            {
                string[] responseList = ftpResponseLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string permissions = responseList[0];
                //Get directory, currently only checking for not "-", might be beneficial to also check for "d" when mapping IsDirectory
                IsDirectory = !string.Equals(permissions.ElementAt(0), "-");
                //Get directory, currently only checking for not "-", might be beneficial to also check for r,w,x when mapping permissions
                //Get Owner Permissions
                OwnerRead = !string.Equals(permissions.ElementAt(1), "-");
                OwnerWrite = !string.Equals(permissions.ElementAt(2), "-");
                OwnerExecute = !string.Equals(permissions.ElementAt(3), "-");
                //Get Group Permissions
                GroupRead = !string.Equals(permissions.ElementAt(4), "-");
                GroupWrite = !string.Equals(permissions.ElementAt(5), "-");
                GroupExecute = !string.Equals(permissions.ElementAt(6), "-");
                //Get Other Permissions
                OtherRead = !string.Equals(permissions.ElementAt(7), "-");
                OtherWrite = !string.Equals(permissions.ElementAt(8), "-");
                OtherExecute = !string.Equals(permissions.ElementAt(9), "-");
                NumberOfLinks = int.Parse(responseList[1]);
                Size = int.Parse(responseList[4]);
                string dateStr = responseList[5] + " " + responseList[6] + " " + responseList[7];
                //Setting Year to the current year, can be changed if needed
                dateStr += " " + DateTime.Now.Year.ToString("yyyy");
                ModifiedDate = DateTime.ParseExact(dateStr, "MMM dd hh:mm yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
                Name = (responseList[8]);
                ParsingError = false;
            }
            catch (Exception ex)
            {
                ParsingException = ex;
                ParsingError = true;
            }
        }
    }
