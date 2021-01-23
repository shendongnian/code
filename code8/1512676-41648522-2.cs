       var sb = new StringBuilder();
                var valuelist = new List<GraphData>();
                //want to remove this or make it cleaner
                foreach (var result in datalist.DistinctBy(x => x.Label).Select(x => x.Label))
                {
                    var childItems = datalist.
                        Where(x => x.Label == result).Select(x => x.Data).ToList();
    
                    valuelist.Add(new GraphData() { Label = result, Data = childItems.ToArray() });
    
                    sb.Append(@"{""data"":");
                    sb.Append("[");
    
                    foreach (var value in childItems)
                    {
                        sb.Append(string.Format("[{0},{1}],", value.No, value.Value));
                    }
    
                    var index = sb.ToString().LastIndexOf(',');
    
                    if (index >= 0)
                        sb.Remove(index, 1);
    
                    sb.Append("],");
                    sb.Append(string.Format(@"""{0}"":""{1}""", "label", result));
                    sb.Append("},");
                }
                var testdata = new JavaScriptSerializer().Serialize(valuelist);
                var datastr = "[" + sb.ToString().Trim(',') + "]";
