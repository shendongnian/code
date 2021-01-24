    [Activity(Label = "@string/ApplicationName",
            Icon = "@drawable/Icon")]
        public class PersonalDetailsActivity : Activity
        {
            ...
            private ISharedPreferencesEditor prefEditor;
            private ISharedPreferences preferences;
            ...
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                SetContentView(Resource.Layout.PersonalDetailView);
    
                preferences = Application.Context.GetSharedPreferences("AppName", FileCreationMode.Private);
    
    
                PopulatePersistedData();
            }
    
            private void PopulatePersistedData()
            {
                myId = preferences.GetInt(nameof(myData.Id), 0);
    
                name.Text = preferences.GetString(nameof(myData.Name), null);
                address.Text = preferences.GetString(nameof(myData.Address), null);
                city.Text = preferences.GetString(nameof(myData.City), null);
                county.Text = preferences.GetString(nameof(myData.County), null);
                emailAddress.Text = preferences.GetString(nameof(myData.Email), null);
                phoneNumber.Text = preferences.GetString(nameof(myData.PhoneNumber), null);
                bio.Text = preferences.GetString(nameof(myData.Bio), null);
                rating.Rating = 5;
    
            }
    
            private void SaveButton_Click(object sender, EventArgs e)
            {
                prefEditor = preferences.Edit();
    
                myData = new Citizen();
    
                myData.Name = name.Text;
                myData.Address = address.Text;
                myData.City = city.Text;
                myData.County = county.Text;
                myData.Email = emailAddress.Text;
                myData.PhoneNumber = phoneNumber.Text;
                myData.Bio = bio.Text;
    
                prefEditor.PutInt(nameof(myData.Id), myId);
                prefEditor.PutString(nameof(myData.Name), myData.Name);
                prefEditor.PutString(nameof(myData.Address), myData.Address);
                prefEditor.PutString(nameof(myData.City), myData.City);
                prefEditor.PutString(nameof(myData.County), myData.County);
                prefEditor.PutString(nameof(myData.Email), myData.Email);
                prefEditor.PutString(nameof(myData.PhoneNumber), myData.PhoneNumber);
                prefEditor.PutString(nameof(myData.Bio), myData.Bio);
    
                prefEditor.Apply();
                prefEditor.Commit();
    
                var intent = new Intent();
                intent.PutExtra("CitizenName", name.Text);
    
                SetResult(Result.Ok, intent);
                this.Finish();
            }
        }
