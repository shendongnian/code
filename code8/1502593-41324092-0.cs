        public static StorageAccountParseResult TryParseAccount(string connectionString, out CloudStorageAccount account)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                account = null;
                return StorageAccountParseResult.MissingOrEmptyConnectionStringError;
            }
            CloudStorageAccount possibleAccount;
            if (!CloudStorageAccount.TryParse(connectionString, out possibleAccount))
            {
                account = null;
                return StorageAccountParseResult.MalformedConnectionStringError;
            }
            account = possibleAccount;
            return StorageAccountParseResult.Success;
        }
