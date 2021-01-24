    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using HtmlAgilityPack;
    using System.Web;
    namespace test
    {
        class Program
        {
        public static void Main(string[] args)
        { 
                string html = "<tr>" +
                    "<td>" +
                    "<div onmouseover = \"toggle('clue_J_1_1', 'clue_J_1_1_stuck', '<em class=&quot;correct_response&quot;>Obama</em><br/><br/><table width=&quot;100%&quot;><tr><td class=&quot;right&quot;>Kailyn</td></tr></table>')\" onmouseout = \"toggle('clue_J_1_1', 'clue_J_1_1_stuck', 'Michelle LaVaughn Robinson')\" onclick = \"togglestick('clue_J_1_1_stuck')\"></div></td></tr>";
                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                //Console.WriteLine(doc.DocumentNode.OuterHtml);
                string toggle = doc.DocumentNode.SelectSingleNode("//tr//td/div[@onmouseover]").GetAttributeValue("onmouseover", "FAILED");
                //Clean up string
                //Console.WriteLine(toggle);
                //Get Variables from toggle()
                List<string> toggleVariables = new List<string>();
                bool flag = false; string temp = "";
                for(int i=0; i<toggle.Length; i++)
                {
                    if (toggle[i] == '\'' && flag== true)
                    {
                        toggleVariables.Add(temp);
                        temp = "";
                        flag = false;
                    }
                    else if (flag)
                    {
                        temp += toggle[i];
                    }
                    else if (toggle[i] == '\'')
                    {
                        flag = true;
                    }
                }
                //Make it into workable HTML
                toggleVariables[2] = HttpUtility.HtmlDecode(toggleVariables[2]);
                //New HtmlDocument
                HtmlDocument htmlInsideToggle = new HtmlDocument();
                htmlInsideToggle.LoadHtml(toggleVariables[2]);
                Console.WriteLine(htmlInsideToggle.DocumentNode.OuterHtml);
                Console.ReadKey();
        }
    }
