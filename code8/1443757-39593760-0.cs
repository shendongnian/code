    foreach (TaskChaptersModel chapter in listChapter)
    {
    	if (chapter.chapterNo == null || chapter.chapterNo == "-1")
    	{
    		continue;
    	}
    
    	paragraph = doc.Content.Paragraphs.Add();
    	paragraph.Range.Text = chapter.chapterNo + " " + chapter.chapterName;
    
    	//标题1
    	if (!chapter.chapterNo.Contains("."))
    	{
    		paragraph.Range.Font.Name = "宋体";//宋体
    		paragraph.Range.Font.Bold = 2;//加粗
    		paragraph.Range.Font.Size = 16;//三号
    		paragraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//水平居中
    	}
    	else if (chapter.chapterNo.Select(c => c == '.').Count() == 1)
    	{
    		paragraph.Range.Font.Name = "宋体";//宋体
    		paragraph.Range.Font.Bold = 2;//加粗
    		paragraph.Range.Font.Size = 16;//三号
    		paragraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;//左对齐
    		paragraph.Format.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
    	}
    	else
    	{
    		paragraph.Range.Font.Name = "宋体";//宋体
    		paragraph.Range.Font.Size = 12;//三号
    		paragraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;//左对齐
    		paragraph.Format.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
    	}
    
    	paragraph.Range.InsertParagraphAfter();
    	paragraph = doc.Content.Paragraphs.Add();                                     
    	//有编辑权限
    	if (chapter.wordFlag == "E")
    	{
    		paragraph.Range.Text = "请您编辑，" + userName;                        
    	}
    	else
    	{
    		paragraph.Range.HighlightColorIndex = Word.WdColorIndex.wdGray25;
    	}
    	paragraph.Range.InsertParagraphAfter();
    }
    
    foreach (Word.Paragraph p in doc.Paragraphs)
    {
    	if (p.Range.Text.Contains("请您编辑"))
    	{
    		p.Range.Select();
    		p.Range.Editors.Add(Word.WdEditorType.wdEditorEveryone);
    	}
    }
