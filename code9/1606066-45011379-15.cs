            SetContentView(Resource.Layout.Main);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            var chemicals = new List<Chemical>
            {
                new Chemical {Name = "Niacin", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Biotin", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Chromichlorid", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Natriumselenit", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Manganosulfate", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Natriummolybdate", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Ergocalciferol", DrawableId = Resource.Drawable.Icon},
                new Chemical {Name = "Cyanocobalamin", DrawableId = Resource.Drawable.Icon},
            };
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _adapter = new RecyclerViewAdapter(this,chemicals);
            _LayoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_LayoutManager);
            _recyclerView.SetAdapter(_adapter);//
