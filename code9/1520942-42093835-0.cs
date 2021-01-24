                 public static class FormularDataExtensions
                 {
                    public static Dictionary<string, string> ConvertToDictionary(this FormularData formularData)
                    {
                      var dictionary = new Dictionary<string, string>();
                      if (!string.IsNullOrEmpty(formularData.Item1))
                          dictionary.Add(nameof(formularData.Item1), formularData.Item1);
                      if (!string.IsNullOrEmpty(formularData.Item2))
                          dictionary.Add(nameof(formularData.Item2), formularData.Item2);
                     return dictionary;
                    }
                 }
