     protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            int numero, numero2;
            ImageView imagen1 = FindViewById<ImageView>(Resource.Id.img_Dice1);
            ImageView imagen2 = FindViewById<ImageView>(Resource.Id.img_Dice2);
            Button botonP = FindViewById<Button>(Resource.Id.btnRoll);
            Random ran = new Random();
          
            int[] myImage = {
                Resource.Drawable.uno,
                Resource.Drawable.dos,
                Resource.Drawable.tres,
                Resource.Drawable.cuatro,
                Resource.Drawable.cinco,
                Resource.Drawable.seis
            };
            botonP.Click += (sender, e) =>
            {
                
                numero = ran.Next(0, 6);
                
                numero2 = ran.Next(0, 6);
                Console.WriteLine(numero + " " + numero2);
                imagen1.SetImageResource(myImage[numero]);
                imagen2.SetImageResource(myImage[numero2]);
            };
        }
