            var x = 1;
            var type = row.Cells[3].Value.GetType();
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int32:
                    // It's an int
                    if(row.Cells[3].Value == null || row.Cells[3].Value < 0){
                       e.Cancel = true;
                       row.ErrorText = "Positive number is required";
                       MessageBox.Show(row.ErrorText);
                    }
                    break;
                case TypeCode.String:
                    // It's a string
                    if (string.IsNullOrEmpty((string)row.Cells[3].Value)){
                       e.Cancel = true;
                       row.ErrorText = "Errortext";
                       MessageBox.Show(row.ErrorText);
                    }
                    break;
            }
