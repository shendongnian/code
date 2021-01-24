        public class MyContextUtility : IContextUtility
        {
            public string GetAssetTxt(string str)
            {
                string strToReturn = null;
                using (var stream = Application.Context.Assets.Open(str))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        strToReturn=reader.ReadToEnd();
                    }
                }
                return strToReturn;
            }
        }
