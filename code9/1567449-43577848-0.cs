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
            string url = "Http://catfacts-api.appspot.com/api/facts/?number=5";
            JsonValue json = await FetchInfoAsync(url);
            updateCats(json);
        };
    }
      private void updateCats(JsonValue json)
      {
          // get next random int between 0 and 4
          int ndx = rand.Next(4);
          _catFactsTextView.Text = json["facts"][ndx];
      }
