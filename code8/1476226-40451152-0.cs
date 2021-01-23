    namespace MyApp.Models
    {
        public static class CartExtension
        {
            /// <summary>
            /// Apply the formatting defined by the DisplayFormatAttribute on one of the Cart object's properties
            /// programatically. Useful if the property is being rendered on screen, but not via the usual Html.DisplayFor
            /// method (e.g. via Javascript or some other method)
            /// </summary>
            /// <param name="cart"></param>
            /// <param name="propertyName"></param>
            /// <returns></returns>
            public static string ApplyFormattingTo(this Cart cart, string propertyName)
            {
                var property = cart.GetType().GetProperty(propertyName);
                var attriCheck = property.GetCustomAttributes(typeof(DisplayFormatAttribute), false);
                if (attriCheck.Any())
                {
                    return string.Format(((DisplayFormatAttribute)attriCheck.First()).DataFormatString, property.GetValue(cart, null));
                }
                return "";
            }
        }
    }
