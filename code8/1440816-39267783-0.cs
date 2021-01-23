    foreach (string item in textArr)
            {
                if (string.IsNullOrEmpty(item)) continue;
                string[] itemArr = item.Split(' ');
                if (
                    itemArr[0] == 'HIS' or
                    itemArr[0] == 'FRAG'
                   ) continue;
                DataRow row=Data.NewRow();
                row["RecordHeader"]=itemArr[0];
                row["ClientName"] = itemArr[1];
                row["Date1"] = itemArr[2];
                row["Date2"] = itemArr[3];
                Data.Rows.Add(row);
            }
