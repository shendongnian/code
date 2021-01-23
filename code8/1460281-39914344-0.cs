    public ActionFlagsViewModel StackActionFlagsViewModels(List<ActionFlagsViewModel> afList)
        {
            var result = new ActionFlagsViewModel();
            foreach (var propInfo in typeof(ActionFlagsViewModel).GetProperties().Where(p => p.PropertyType == typeof(System.Boolean)))
            {
                propInfo.SetValue(result, (from m in afList where (bool)propInfo.GetValue(m) select true).FirstOrDefault());
                //propInfo.SetValue(result, afList.Where(afvm => Convert.ToBoolean(propInfo.GetValue(afvm)) == true).Any());
            }
            return result;
        }
Well this works!
Both statements work. But which one is better ? 
