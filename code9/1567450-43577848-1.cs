    public class MainActivity : Activity
    {
      private ImageButton _mrWhiskersButton;
      private TextView _catFactsTextView;
      private System.Random rand;
    
      protected override void OnCreate(Bundle bundle)
      {
        base.OnCreate(bundle)
     
        rand = new System.Random();
        
        // omitted code...
        _mrWhiskersButton.Click += async delegate
        {
            // get next random int between 1 and 5
            int ndx = rand.Next(1,5);
            string url = $"Http://catfacts-api.appspot.com/api/facts?number={ndx}";
            JsonValue json = await FetchInfoAsync(url);
            updateCats(json);
        };
    }
      private void updateCats(JsonValue json)
      {
          foreach (var fact in json["facts"]) {
            _catFactsTextView.Text += fact + "\n";          
          }
          
      }
