    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Text.RegularExpressions;
    public static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("article.xml");
        //only selects <p>'s that already have 3 or more refs. No need to check paragraphs that don't even have enough refs
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("//*[count(xref[@ref-type='bibr' and starts-with(@rid,'ref')])>2]");
        List<string> results = new List<string>();
            
        //Foreach <p>
        foreach (XmlNode x in nodes)
        {
            XmlNodeList xrefs = x.SelectNodes(".//xref[@ref-type='bibr' and starts-with(@rid,'ref')]");
            List<StartEnd> startEndOfEachTag = new List<StartEnd>(); // we mark the start and end of each ref.
            string temp = x.OuterXml; //the paragraph we're checking
            //finds start and end of each tag xref tag
            foreach (XmlNode xN in xrefs){ //We find the start and end of each paragraph
                StartEnd se = new StartEnd(temp.IndexOf(xN.OuterXml), temp.IndexOf(xN.OuterXml) + xN.OuterXml.Length);
                startEndOfEachTag.Add(se);  
            }
            /* THis comment shows the regex command used and how we build the regular expression we are checking with.
            string regexTester = "<xref ref-type=\"bibr\" rid=\"ref2\">\\[2\\]<\\/xref>([ ]|(, ))<xref ref-type=\"bibr\" rid=\"ref3\">\\[3\\]<\\/xref>";
            Match matchTemp = Regex.Match(temp.Substring(startEndOfEachTag[0].start, startEndOfEachTag[1].end - startEndOfEachTag[0].start), regexTester);
            */
            //we go through all the xrefs
            for (int i=0; i<xrefs.Count; i++)
            {
                int newIterator = i; //This iterator prevents us from creating duplicates.
                string regCompare = Regex.Escape(xrefs[i].OuterXml); // The start xref
                int count = 1; //we got one xref to start with we need at least 3
                string tempRes = ""; //the string we store the result in
                for(int j=i+1; j<xrefs.Count; j++) //we check with the other xrefs to see if they follow immediately after.
                {
                    regCompare += "([ ]|(, ))" + Regex.Escape(xrefs[j].OuterXml); //we check that the the xref comes exactly after a space or a comma and space
                    Match matchReg = Regex.Match(temp.Substring(startEndOfEachTag[i].start, startEndOfEachTag[j].end - startEndOfEachTag[i].start),
                        regCompare); //we get the result
                    if (matchReg.Success){
                        count++; //it was a success so we increment the number of xrefs we matched
                        tempRes = matchReg.Value; // we add it to out temporary result.
                        newIterator = j; //update where i should start from next time.
                    }
                    else {
                        i = j; // we failed and i should start from here now.
                        break;
                    }
                }
                i = newIterator;
                if (count > 2){
                    results.Add(tempRes);
                }
            }
        }
        Console.ReadKey();
    }
