	using System;
	using ATL.AudioData;
	using System.Collections.Generic;
	
	AudioDataManager theFile = new AudioDataManager(AudioData.AudioDataIOFactory.GetInstance().GetDataReader(<fileLocation>));
	Dictionary<uint, ChapterInfo> expectedChaps = new Dictionary<uint, ChapterInfo>();
	TagData theTag = new TagData();
	theTag.Chapters = new List<ChapterInfo>();
	expectedChaps.Clear();
	ChapterInfo ch = new ChapterInfo();
	ch.StartTime = 123;
	ch.StartOffset = 456;
	ch.EndTime = 789;
	ch.EndOffset = 101112;
	ch.UniqueID = "";
	ch.Title = "aaa";
	ch.Subtitle = "bbb";
	ch.Url = "ccc\0ddd";
	theTag.Chapters.Add(ch);
	expectedChaps.Add(ch.StartTime, ch);
	ch = new ChapterInfo();
	ch.StartTime = 1230;
	ch.StartOffset = 4560;
	ch.EndTime = 7890;
	ch.EndOffset = 1011120;
	ch.UniqueID = "002";
	ch.Title = "aaa0";
	ch.Subtitle = "bbb0";
	ch.Url = "ccc\0ddd0";
	theTag.Chapters.Add(ch);
	expectedChaps.Add(ch.StartTime, ch);
	// Persists the chapters
	theFile.UpdateTagInFile(theTag, MetaDataIOFactory.TAG_ID3V2);
	// Reads them
	theFile.ReadFromFile(null, true);
	foreach (ChapterInfo chap in theFile.ID3v2.Chapters)
	{
		System.Console.WriteLine(chap.Title + "(" + chap.StartTime + ")");
	}
