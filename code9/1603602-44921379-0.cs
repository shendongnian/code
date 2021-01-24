    public class MyActivity : Activity, IOnSuccessListener, IOnFailureListener, IValueEventListener
    {
        private DatabaseReference dbRef;
        private StorageReference imagesRef;
        private int count;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            // Create your application here
            SetContentView(Resource.Layout.layout2);
    
            FirebaseAuth mAuth = FirebaseAuth.Instance;
            FirebaseUser user = mAuth.CurrentUser;
            if (user == null)
            {
                var result = mAuth.SignInAnonymously();
            }
    
            FirebaseDatabase database = FirebaseDatabase.Instance;
            dbRef = database.GetReference("mygallery");
    
            FirebaseStorage storage = FirebaseStorage.Instance;
            //create child reference
            StorageReference storageRef = storage.Reference;
            imagesRef = storageRef.Child("images");
    
            Button btn = FindViewById<Button>(Resource.Id.createdb);
            btn.Click += Btn_Click;
        }
    
        private void Btn_Click(object sender, EventArgs e)
        {
            //upload to firebase storage
            for (int i = 0; i < 5; i++)
            {
                StorageReference oneRef = imagesRef.Child("one" + i + ".png");
                Bitmap bitmap = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.one);
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                byte[] data = stream.ToArray();
    
                UploadTask uploadtask = oneRef.PutBytes(data);
                uploadtask.AddOnSuccessListener(this);
                uploadtask.AddOnFailureListener(this);
            }
        }
    
        public void OnFailure(Java.Lang.Exception e)
        {
            Log.WriteLine(LogPriority.Debug, "storage", "Failed:" + e.ToString());
            Toast.MakeText(Application.Context, "Failed", ToastLength.Short);
        }
    
        public void OnSuccess(Java.Lang.Object result)
        {
            Log.WriteLine(LogPriority.Debug, "storage", "success!");
            Toast.MakeText(this, "Success", ToastLength.Short);
    
            //retrieve url and name of uploaded image and insert to database
            var snapshot = result as SnapshotBase;
            var name = snapshot.Storage.Name;
            var uri = snapshot.Storage.Path;
            dbRef.Child(count.ToString()).Child("name").SetValue(name);
            dbRef.Child(count.ToString()).Child("imageurl").SetValue(uri);
            count++;
        }
    
        public void OnCancelled(DatabaseError error)
        {
            Log.WriteLine(LogPriority.Debug, "database", "Cancelled:" + error.ToString());
            Toast.MakeText(Application.Context, "Failed", ToastLength.Short);
        }
    
        public void OnDataChange(DataSnapshot snapshot)
        {
            Toast.MakeText(Application.Context, "Success", ToastLength.Short);
        }
    }
