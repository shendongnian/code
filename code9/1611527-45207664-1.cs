    public class KanbanCard
    {
        static void Main(string[] args)
        {
            const string USER_ID = "niket";
            var cardMetadata = FindCardMetaData(USER_ID);
        }
        static string FindCardMetaData(string userId)
        {
            KanbanMetadataService.iformPortTypeClient MetadataClient = new iformPortTypeClient("iformServiceSOAP11port");
            return MetadataClient.getCardMetadata(new getCardMetadata_Input()
            {
                userLoginId = userId,
                cardType = "KanbanDefect"
            });
        }
    }
