                void MyClear()
            {
                int count = 0;
                foreach (System.Reflection.PropertyInfo item in typeof(ViewCommonVm).GetProperties())
                {
                    ViewCommonItemVM common = (ViewCommonItemVM)item.GetValue(this);
                    if (common.Data.Count() != 0)
                    {
                        count++;
                        if (count > 4 && common.Data.Count != 0)
                            common.Data.Clear();
                    }
                }
            }
