    class App : Application {
        public static Model GlobalModel { get; set; }
        //...
    }
    
    class Model {
        public Color UserSelectedColor { get; set; }
    }
    
    class Page1 {
        //...
        private void StoreSelectedColor(Color selectedColor) {
            App.GlobalModel.UserSelectedColor = selectedColor;
        }
        //...
    }
    
    class Page2 {
        //...
        private Color GetSelectedColor() {
            return App.GlobalModel.UserSelectedColor;
        }
        //...
    }
