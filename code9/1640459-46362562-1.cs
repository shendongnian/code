    List<string> InputLineList;
                while ((line = sr.ReadLine()) != null)
            {
              InputLineList = new List<string>();
               // InputLineList.Clear();
                // Slice Substrings
                string AP = line.Substring(0, 7);
                string Address = line.Substring(8, 45);
                string JDate = line.Substring(54, 3);
                string BMFline = line.Substring(57, 6);
                string POD = line.Substring(68, 11);
                string DateApok = line.Substring(79, 4);
                string checkdigit1 = line.Substring(83, 1);
                string poso = line.Substring(84, 9);
                string checkdigit2 = line.Substring(93, 1);
                string GDate = line.Substring(94, 8);
                string AType = line.Substring(102, 2);
                string NinPacket = line.Substring(106, 5);
                // Construct List
                InputLineList.Add(AP);
                InputLineList.Add(Address);
                InputLineList.Add(JDate);
                InputLineList.Add(BMFline);
                InputLineList.Add(POD);
                InputLineList.Add(DateApok);
                InputLineList.Add(checkdigit1);
                InputLineList.Add(poso);
                InputLineList.Add(checkdigit2);
                InputLineList.Add(GDate);
                InputLineList.Add(AType);
                InputLineList.Add(NinPacket);
                //Console.WriteLine(InputLineList[0] + InputLineList[1] + InputLineList[2]);
                //BaseDict.niarxosfileadv.Add(POD, InputLineList);
                BaseDict.myLists.Add(POD, InputLineList);
                Console.WriteLine(BaseDict.myLists[POD][0] + BaseDict.myLists[POD][1] + BaseDict.myLists[POD][2]);
            }
            ...
