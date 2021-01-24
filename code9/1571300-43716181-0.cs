      public static string GetLocalisedUrl(Uri initialUri, IList<string> controllersNames, IList<string> userLangs)
        {
            var res = string.Empty;
            var supportedLocales = GetSupportedLocales();
            var origUrl = initialUri;
            // Dicide requested url to parts
            var cleanedSegments = origUrl.Segments.Select(X => X.Replace("/", "")).ToList();
            // Check is already supported locale defined in route
            // cleanedSegments[0] is empty string, so lang parameter will be in [1] url segment
            var isLocaleDefined = cleanedSegments.Count > 1 && supportedLocales.Contains(cleanedSegments[1]);
            cleanedSegments = cleanedSegments.ConvertAll(d => d.ToLower());
            // does request need to be changed
            var isRequestPathToHandle =
                // Url has controller's name part
                (cleanedSegments.Count > 1 && cleanedSegments.Intersect(controllersNames).Count() > 0) ||
                // This condition is for default (initial) route
                (cleanedSegments.Count == 1) ||
                // initial route with lang parameter that is not supported -> need to change it
                (cleanedSegments.Count == 2 && !supportedLocales.Contains(cleanedSegments[1]));     
            if (!isLocaleDefined && isRequestPathToHandle)
            {
                var langVal = "";
                // Get user preffered language from Accept-Language header
                if (userLangs != null && userLangs.Count > 0)
                {
                    // For our locale name approach we'll take only first part of lang-locale definition
                    var splitted = userLangs[0].Split(new char[] { '-' });
                    langVal = splitted[0];
                }
                // If we don't support requested language - then redirect to requested page with default language
                if (!supportedLocales.Contains(langVal))
                    langVal = supportedLocales[0];
                var normalisedPathAndQuery = origUrl.PathAndQuery;
                if ((cleanedSegments.Count > 2 &&
                    !controllersNames.Contains(cleanedSegments[1].ToLower()) &&
                    controllersNames.Contains(cleanedSegments[2].ToLower())) ||
                    (cleanedSegments.Count == 2) && (!controllersNames.Contains(cleanedSegments[1])))
                {
                    // Second segment contains lang parameter, third segment contains controller name
                    cleanedSegments.RemoveAt(1);
                    // Remove wrong locale name from initial Uri
                    normalisedPathAndQuery = string.Join("/", cleanedSegments) + origUrl.Query;
                }
                // Finally, create new uri with language loocale
                res = string.Format("{0}://{1}:{2}/{3}{4}", origUrl.Scheme, origUrl.Host, origUrl.Port, langVal.ToLower(), normalisedPathAndQuery.ToLower());
            }
            return res;
        }
