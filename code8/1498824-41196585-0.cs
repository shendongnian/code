    class Program {
	void main(string args[]) {
	
		String folderPath = Properties.Setings.Default.folder;
		int folderSizeLimit = Properties.Setings.Default.sizeLimit;
		int amountToDelete = Properties.Setings.Default.toDelete;
		DeleteOldFilesIfOverFolderLimit(folderPath, folderSizeLimit, amountToDelete);
	}
	private private void DeleteOldFilesIfOverFolderLimit(string folderPath,
                                             long folderSizeLimit,
                                             long amountToDelete)
		...... from other post .....
    }
