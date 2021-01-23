            void RemoveElementsHiddenByStyles(CQ selector)
            {
                var parser = new Parser();
                foreach (IDomElement style in selector.Select("style"))
                {
                    StyleSheet stylesheet = parser.Parse(style.InnerText);
                    foreach (StyleRule styleRule in stylesheet.StyleRules)
                    {
                        if (styleRule.Declarations.Any(d => d.Name == "display" && d.Term.ToString() == "none"))
                        {
                            selector.Select(styleRule.Selector.ToString()).Remove();
                        }
                    }
                }
            }
