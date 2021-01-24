      public static class ProductCategoryExtensions {
        // please, notice "this" for the extension method
        public static string IconName(this ProductCategory value) {
          switch (value) {
            case ProductCategory.Food:
              return "apple.jpg";
            case ProductCategory.Clothes:
              return "tshirt.jpg";
            //TODO: add all the other categories here
            default:
              return "Unknown.jpg"; 
          }
        }
      }
