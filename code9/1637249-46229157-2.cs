    class Program
    {
        static void Main(string[] args)
        {
            var disbursements =
                JsonConvert.DeserializeObject<Disbursements>(
                    File.ReadAllText(
                        "data.json",
                        Encoding.UTF8
                    )
                );
            foreach (var disbursement in disbursements.Items)
            {
                disbursement.StatusCode = 166000005;
            }
            string modifiedContent = JsonConvert.SerializeObject(disbursements);
            File.WriteAllText(
                "modifiedData.json",
                modifiedContent,
                Encoding.UTF8
            );
        }
    }
