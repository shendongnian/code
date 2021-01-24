        [TestMethod]
        public void RegexSerialization()
        {
            MedicalServiceClient client = new MedicalServiceClient();
            // Save a test value
            int patient_recid = 15478;
            DateTime tservice = new DateTime(2017, 4, 28);
            byte[] _transcriptStrokes = null;
            string _transcript = null;
            MyClass test_1 = new MyClass
            {
                TopLeft = new Point(24.11, 36.22),
                fontWeight = FontWeights.Bold,
                fontStyle = FontStyles.Italic,
                Message = "This is my first test string."
            };
            MyClass test_2 = new MyClass
            {
                TopLeft = new Point(14.15, 24.22),
                fontWeight = FontWeights.Light,
                fontStyle = FontStyles.Oblique,
                Message = "This is my second test string."
            };
            MyClass test_3 = new MyClass
            {
                TopLeft = new Point(7, 12),
                fontWeight = FontWeights.Thin,
                fontStyle = FontStyles.Normal,
                Message = "This is my third test string."
            };
            List<MyClass> _mylist = new List<MyClass>();
            _mylist.Add(test_1);
            _mylist.Add(test_2);
            _mylist.Add(test_3);
            _transcript = string.Empty;
            foreach(var s in _mylist)
            {
                // serialize 
                string _s = string.Format("\u0001({0},{1}),{2},{3}\u0003{4}",
                         s.TopLeft.X, s.TopLeft.Y, s.fontStyle, s.fontWeight, s.Message);
                _transcript = _transcript + _s;
            }
                
            // Save to backend database.
            client.SaveDrawingTranscipt(patient_recid, tservice, _transcriptStrokes, _transcript);
            // Recall from backend database.
            List<MyClass> _newlist = new List<MyClass>();
            progress_note_drawing_transcription pndt = client.GetDrawingTranscript(patient_recid, tservice);
            // regex pattern for integer or double. The (?:  starts a non-capturing group. The ? after ) makes the .d+ purely optional.
            Regex r = new Regex(@"\((\d+(?:\.\d+)?),(\d+(?:\.\d+)?)\),(\w+),(\w+)\u0003(.*)");
            // Parse the transcription field into multiple strings using the non-printable character \x01
            string pattern = @"\u0001";
            string input = pndt.transcription;
            string[] result = Regex.Split(input, pattern);
            for (int ctr = 0; ctr < result.Length; ctr++)
            {
                if (string.IsNullOrEmpty(result[ctr]))
                     continue;
                
                Match m = r.Match(result[ctr]);
                if (m.Success)
                {
                    MyClass _mc = new MyClass();
                    Point _p = new Point();
                    _p.X = double.Parse(m.Groups[1].Value);
                    _p.Y = double.Parse(m.Groups[2].Value);
                    _mc.TopLeft = _p;
                    _mc.fontStyle = (FontStyle)new FontStyleConverter().ConvertFromString(m.Groups[3].Value);
                    _mc.fontWeight = (FontWeight)new FontWeightConverter().ConvertFromString(m.Groups[4].Value);
                    _mc.Message = m.Groups[5].Value;
                    _newlist.Add(_mc);
                }
            }
            Assert.AreEqual(_mylist[0].TopLeft, _newlist[0].TopLeft);
            Assert.AreEqual(_mylist[1].TopLeft, _newlist[1].TopLeft);
            Assert.AreEqual(_mylist[2].TopLeft, _newlist[2].TopLeft);
            Assert.AreEqual(_mylist[0].fontStyle, _newlist[0].fontStyle);
            Assert.AreEqual(_mylist[1].fontStyle, _newlist[1].fontStyle);
            Assert.AreEqual(_mylist[2].fontStyle, _newlist[2].fontStyle);
            Assert.AreEqual(_mylist[0].fontWeight, _newlist[0].fontWeight);
            Assert.AreEqual(_mylist[1].fontWeight, _newlist[1].fontWeight);
            Assert.AreEqual(_mylist[2].fontWeight, _newlist[2].fontWeight);
        }
