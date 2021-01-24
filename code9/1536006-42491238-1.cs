    string AttachmentFileContents = "";
    
    AttachmentFileContents = File.ReadAllText(FormDataFilePath);
    
    string checkSumAugmentationNumber = new Checksum().GetChecksum(AttachmentFileContents);
