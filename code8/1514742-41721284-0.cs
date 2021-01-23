    foreach (var x in DataList)
            {
                var itemRefCode = RefCodesList.FirstOrDefault(d => d.old_code == x.code);
                if (itemRefCode != null)
                {
                    x.code = itemRefCode.new_code;
                    x.name = itemRefCode.new_name;
                }
            }
