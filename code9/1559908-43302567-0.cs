    public static class HtmlElementHelper
        {
            public static string Val(this WebBrowser wb, string id, string Val = null)
            {
                HtmlElement ele = wb.Document.GetElementById(id);
                if (ele.IsNotNull())
                {
                    HTMLInputElement txtele = (HTMLInputElement)ele.DomElement;
                    if (Val.IsNull())
                        Val = txtele.value;
                    else
                        txtele.value = Val; 
                }
                return Val;
            }
            public static void eleClick(this WebBrowser wb, string id)
            {
                HtmlElement ele = wb.Document.All[id];
                if (ele.IsNotNull())
                {
                    switch (ele.TagName.ToLower())
                    {
                        case "input":
                            HTMLButtonElement btnele = (HTMLButtonElement)ele.DomElement;
                            btnele.click();
                            break;
                        case "a":
                            HTMLAnchorElement ancele = (HTMLAnchorElement)ele.DomElement;
                            ancele.click();
                            break;
                    } 
                }
            }
            public static void eleClick(this WebBrowser wb, string tag, string data)
            {
                HtmlElementCollection eleCollection = wb.Document.GetElementsByTagName(tag);
                foreach (HtmlElement ele in eleCollection)
                {
                    if (ele.InnerHtml.ToCString().ToLower() == data)
                    {
                        switch (tag)
                        {
                            case "a":
                                 HTMLAnchorElement ancele = (HTMLAnchorElement)ele.DomElement;
                                ancele.click();
                                break;
                        }
                        break;
                    }
                }
            }
            public static string Html(this WebBrowser wb, string id, string val = null)
            {
                HtmlElement ele = wb.Document.GetElementById(id);
                if (ele.IsNotNull())
                {
                    switch (ele.TagName.ToLower())
                    {
                        case "span":
                            HTMLSpanElement spanEle = (HTMLSpanElement)ele.DomElement;
                            if (val.IsNull())
                                val = spanEle.innerHTML;
                            else
                                spanEle.innerHTML = val;
                            break;
                        case "div":
                            HTMLDivElement divEle = (HTMLDivElement)ele.DomElement;
                            if (val.IsNull())
                                val = divEle.innerHTML;
                            else
                                divEle.innerHTML = val;
                            break;
                    } 
                }
                return val;
            }
            public static string Style(this WebBrowser wb, string id)
            {
                HtmlElement ele = wb.Document.All[id];
                return ele.Style.ToCString();
            }
            public static string Attr(this WebBrowser wb, string id, string key, string val=null,bool isTag=false,string data =null)
            {
                if (!isTag)
                {
                    HtmlElement ele = wb.Document.All[id];
                    if (val.IsNull())
                        val = ele.GetAttribute(key);
                    else
                        ele.SetAttribute(key, val); 
                }
                else
                {
                    HtmlElementCollection eleCollection = wb.Document.GetElementsByTagName(id);
                    foreach (HtmlElement ele in eleCollection)
                    {
                        if (ele.InnerHtml.ToCString().ToLower().Contains(data))
                        {
                            switch (id)
                            {
                                case "a":
                                    if (val.IsNull())
                                        val = ele.GetAttribute(key);
                                    else
                                        ele.SetAttribute(key, val);
                                    break;
                            }
                            break;
                        }
                    }
                }
                return val;
            }
               
        }
