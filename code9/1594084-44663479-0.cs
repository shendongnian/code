            //STEP 1 CODE STARTS HERE
            A.Table table1=graphicData1.GetFirstChild<A.Table>();
            A.TableRow tableRow1=table1.GetFirstChild<A.TableRow>();
            A.TableRow tableRow2=table1.Elements<A.TableRow>().ElementAt(1);
            A.TableCell tableCell1=tableRow1.Elements<A.TableCell>().ElementAt(2);
            A.TableCellProperties tableCellProperties1=tableCell1.GetFirstChild<A.TableCellProperties>();
            A.BottomBorderLineProperties bottomBorderLineProperties1 = new A.BottomBorderLineProperties(){ Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };
            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor(){ Val = A.SchemeColorValues.Text1 };
            solidFill1.Append(schemeColor1);
            A.PresetDash presetDash1 = new A.PresetDash(){ Val = A.PresetLineDashValues.Solid };
            A.Round round1 = new A.Round();
            A.HeadEnd headEnd1 = new A.HeadEnd(){ Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };
            A.TailEnd tailEnd1 = new A.TailEnd(){ Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };
            bottomBorderLineProperties1.Append(solidFill1);
            bottomBorderLineProperties1.Append(presetDash1);
            bottomBorderLineProperties1.Append(round1);
            bottomBorderLineProperties1.Append(headEnd1);
            bottomBorderLineProperties1.Append(tailEnd1);
            tableCellProperties1.Append(bottomBorderLineProperties1);
            //STEP 1 CODE ENDS HERE
            //STEP 2 CODE STARTS HERE
            A.TableCell tableCell2=tableRow2.Elements<A.TableCell>().ElementAt(2);
            A.TableCellProperties tableCellProperties2=tableCell2.GetFirstChild<A.TableCellProperties>();
            A.BottomBorderLineProperties bottomBorderLineProperties2=tableCellProperties2.GetFirstChild<A.BottomBorderLineProperties>();
            A.TopBorderLineProperties topBorderLineProperties1 = new A.TopBorderLineProperties(){ Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };
            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor2 = new A.SchemeColor(){ Val = A.SchemeColorValues.Text1 };
            solidFill2.Append(schemeColor2);
            A.PresetDash presetDash2 = new A.PresetDash(){ Val = A.PresetLineDashValues.Solid };
            A.Round round2 = new A.Round();
            A.HeadEnd headEnd2 = new A.HeadEnd(){ Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };
            A.TailEnd tailEnd2 = new A.TailEnd(){ Type = A.LineEndValues.None, Width = A.LineEndWidthValues.Medium, Length = A.LineEndLengthValues.Medium };
            topBorderLineProperties1.Append(solidFill2);
            topBorderLineProperties1.Append(presetDash2);
            topBorderLineProperties1.Append(round2);
            topBorderLineProperties1.Append(headEnd2);
            topBorderLineProperties1.Append(tailEnd2);
            tableCellProperties2.InsertBefore(topBorderLineProperties1,bottomBorderLineProperties2);
