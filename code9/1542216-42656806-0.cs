    public static bool HasClass(this HtmlNode node, params string[] classValueArray)
            {
                var classValue = node.GetAttributeValue("class", "");
                var classValues = classValue.Split(' ');
                return classValueArray.All(c => classValues.Contains(c));
            }
