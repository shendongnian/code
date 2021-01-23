    public static class ClientWorkbookExtensions {
        public static void ChangeClientName(this IClientWorkbook workbook, String newName) {
            workbook.Name = newName;    //  Or any other code you like
        }
    }
