    public static class CookieHelper
    {
        public static IEnumerable<HttpCookie> SplitCookieValue(this IController con, string cookieName, string cookieValue, int maxValueLength = 394)
        {
            #region Local variables
            var lengthOfCookieValue = cookieValue.Length;
            List<HttpCookie> resultCookieList = new List<HttpCookie>();
            var tempValue = cookieValue.Trim();
            var tempDictionary = new Dictionary<string, string>();
            if (maxValueLength > cookieName.Length) { maxValueLength = maxValueLength - cookieName.Length; }
            
            #endregion
            if (maxValueLength > 4094)
            {
                throw new Exception($"Max value:{maxValueLength} already overflows 4094 bytes!");
            }
            #region Constructing temporary cookie dictionary
            if (lengthOfCookieValue > maxValueLength)
            {
                var charCount = 1;
                var dictionaryCounter = -1;
                do
                {
                    dictionaryCounter++;
                    try
                    {
                        tempDictionary.Add(dictionaryCounter.ToString(), tempValue.Substring(0, maxValueLength));
                        charCount += maxValueLength;
                        tempValue = cookieValue.Substring(charCount - 1, cookieValue.Length - charCount);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                } while (charCount < lengthOfCookieValue);
                if (!string.IsNullOrEmpty(tempValue))
                {
                    tempDictionary.Add((dictionaryCounter).ToString(), tempValue.Substring(0, tempValue.Length)); 
                }
            }
            else
            {
                tempDictionary.Add("", cookieValue);
            }
            #endregion
            #region Constructing results from temporary cookie dictionary
            if (tempDictionary != null)
            {
                foreach (var item in tempDictionary)
                {
                    if (item.Key == "0")
                    {
                        resultCookieList.Add(new HttpCookie($"{cookieName}", $"{item.Value}"));
                    }
                    else
                    {
                        resultCookieList.Add(new HttpCookie($"{cookieName}{item.Key}", $"{item.Value}"));
                    }
                }
            }
            #endregion
            return resultCookieList;
        }
        public static string GetCookiesValue(this IController con, HttpResponseBase p, string cookieName)
        {
            string resultValue = null;
            var resultCookieKeys = p.Cookies.AllKeys.Where(cookiekey => cookiekey.Contains(cookieName));
            if (resultCookieKeys.FirstOrDefault() != null)
            {
                resultValue = string.Empty;
                foreach (var cookieKey in resultCookieKeys)
                {
                    resultValue += p.Cookies[cookieKey].Value;
                }
            }
            return resultValue;
        }
        public static void AddOrOverWriteCookie(this IController con, HttpResponseBase p, string cookieName, string cookieValue, int maxValueSize = 394)
        {
            var allCookiesWhichContainsKey = p.Cookies.AllKeys.Where(cookiekey => cookiekey.Contains(cookieName));
            if (allCookiesWhichContainsKey.FirstOrDefault() != null)
            {
                foreach (var cookieKey in allCookiesWhichContainsKey)
                {
                    p.Cookies.Remove(cookieKey);
                }
            }
            var cookiesToBeWrite = SplitCookieValue(con, cookieName, cookieValue, maxValueSize);
            if (cookiesToBeWrite.Count() > 180)
            {
                // Most of the browsers set their limit to 180 per domain!
                throw new Exception($"Too many cookie! Cookie Count: {cookiesToBeWrite.Count()}{Environment.NewLine}Hint: Try to lower MaxValueSize...");
            }
            foreach (var cookie in cookiesToBeWrite)
            {
                p.Cookies.Add(cookie);
            }
        }
    }
