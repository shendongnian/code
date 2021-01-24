    public sealed partial class MainPage : Page
    {
        ... 
        private async void btnFind_Click(object sender, RoutedEventArgs e)
        {
            ...
            List<int> indexList = await Task.Run(DoStuff(completeText, tofind)); 
            TextHighlighter HighlighterAll = CreateHighlighter(indexList, tofind.Length);
            ...
        }
        private TextHighlighter CreateHighlighter(List<int> listaindex, int lenght)
        {
            ...
            return Higlighter;
        }
        private List<int> DoStuff(string myTxt, string toFind)
        {
            ...
            return indexList;
        }
    }
