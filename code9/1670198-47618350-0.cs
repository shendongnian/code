    using Word = Microsoft.Office.Interop.Word;
    
    public class Agenda {
      public static void Create() {
        Word.Application wordApplication = null;
        Word.Document wdDocument = null;
        Word.Template wdTemplate = null;
        Word.BuildingBlock wdBuildingBlock = null;
    
        object paramBBCategory = "Agenda";
        object paramBBName = "Header";
    
        try {
          wordApplication = new Word.Application();
          wdDocument = wordApplication.Documents.Add(Properties.Settings.Default.Template);
          wdTemplate = (Word.Template)wdDocument.get_AttachedTemplate();
          
          wdBuildingBlock = wdTemplate
            .BuildingBlockTypes.Item(Word.WdBuildingBlockTypes.wdTypeQuickParts)
            .Categories.Item(ref paramBBCategory)
            .BuildingBlocks.Item(ref paramBBName);
          wordBuildingBlock.Insert(wdDocument.Paragraphs.Last.Range);
        } catch { }
      }
    }
