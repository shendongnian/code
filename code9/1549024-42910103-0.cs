           public static class GeneratorHelper{
            
             public static List<SelectListItem> GenerateDropDown(int startvalue, int endValue)
                {
                    var dropDownList = new List<SelectListItem>();
                    for (int i = startvalue; i <= endValue; i++)
                    {
                        string val = i.ToString();
                        dropDownList.Add(new SelectListItem { Text = val, Value = val });
                    }
                    return dropDownList;
                }
           }
