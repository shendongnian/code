    publc string FormatUrl(string url, TestPrimaryObject objTest)
    {
        StringBuilder sb = new StringBuilder();
        if (!String.IsNullOrEmpty(objTest.userId))
        {
            sb.Append($"userId={objTest.userId}");
        }
        if (!String.IsNullOrEmpty(objTest.param2))
        {
            if (sb.Length > 0)
                sb.Append("&");
            sb.Append($"param2={objTest.param2}");
        }
        if (!String.IsNullOrEmpty(objTest.param3))
        {
            if (sb.Length > 0)
                sb.Append("&");
            sb.Append($"param3={objTest.param3}");
        }
        if (!String.IsNullOrEmpty(objTest.param4))
        {
            if (sb.Length > 0)
                sb.Append("&");
            sb.Append($"param4={objTest.param4}");
        }
        return $"{url}?{sb.ToString()}";
    }
