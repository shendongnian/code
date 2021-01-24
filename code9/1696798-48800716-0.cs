                    SqlGeography sqlGeography = SqlGeography.Parse(geoWKT);
                    object geoData = PropertyHelper.GetPrivatePropertyValue<object>(sqlGeography, "GeoData");
                    bool m_isLargerThanAHemisphere = PropertyHelper.GetPrivateFieldValue<bool>(geoData, "m_isLargerThanAHemisphere");
                    if (m_isLargerThanAHemisphere)
                    {
                        sqlGeography = sqlGeography.ReorientObject();
                    }
                    bool isValid = sqlGeography.STIsValid().Value;
                    if (!isValid)
                    {
                        sqlGeography = sqlGeography.MakeValid();
                        isValid = sqlGeography.STIsValid().Value;
                    }
                    DbGeography dbGeography = DbGeography.FromText(sqlGeography.ToString(), 4326);
