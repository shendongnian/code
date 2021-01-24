    public static void Main() {
        try {
             Show(new List<ListItem>(), "");
        }
        catch(Exception ex){
            Console.Write("An error occurred: " + ex.Message);
        }
    }
