				var listAsObj1 = (list1 as IEnumerable).Cast<object>();
				var listAsObj2 = (list2 as IEnumerable).Cast<object>();
				
				var differences = listAsObj1.Except(listAsObj2)            // In 1 (not in 2)
                                    .Concat(listAsObj2.Except(listAsObj1)) // In 2 (not in 1)
                                    .Select(_ => _.ToString());            // As string values
