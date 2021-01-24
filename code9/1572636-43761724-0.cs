        private static void FillError(object sender, FillErrorEventArgs args)
        {
            Uri rowURI;
            if (args.Errors.GetType() == typeof(System.ArgumentException))
            {
                if (Uri.IsWellFormedUriString(args.Values[3].ToString(), UriKind.Absolute))
                {
                    // The URI is valid. This should be ensured in the database update but don't assume it is for defensive coding reasons
                    rowURI = new Uri(args.Values[3].ToString());
                    DataRow myRow = args.DataTable.Rows.Add(new object[]
                  {args.Values[0], args.Values[1], args.Values[2], rowURI, args.Values[4]});
                }
                else
                {
                    // The URI is invalid. Update with a Null value for that field
                    DataRow myRow = args.DataTable.Rows.Add(new object[]
                 {args.Values[0], args.Values[1], args.Values[2], DBNull.Value, args.Values[4]});
                }
               
                args.Continue = true;
            }
        }
