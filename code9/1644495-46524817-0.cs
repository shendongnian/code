     CheckBox checkbox;
        ImageView imageView;
        int estado = 0;
        private ISharedPreferencesEditor editor;
        private ISharedPreferences prefs;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pagina_1);
            //here i am trying to get the value of estado for my checkbox state
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            estado = prefs.GetInt("int_value", 0);
            checkbox = FindViewById<CheckBox>(Resource.Id.checkBox1);
            imageView = FindViewById <ImageView>(Resource.Id.imageView1);
            checkbox.Click += delegate
            {
                if (checkbox.Checked)
                {
                    estado = 1;
                }
                else
                {
                    estado = 0;
                }
                if (estado == 1)
                {
                    checkbox.Checked = true;
                    imageView.SetImageResource(Resource.Drawable.guildwars_icone);
                }
                if (estado == 0)
                {
                    checkbox.Checked = false;
                    imageView.SetImageResource(Resource.Drawable.guardian);
                }
                //THE ERRO CS0136 IS IN THIS prefs
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutInt("int_value", estado);
                editor.Commit();
            };
            
        }
