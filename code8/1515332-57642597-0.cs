<select asp-for="Status" class="form-control" asp-items="@Html.GetEnumSelectList<Cart.CartStatus>()"></select>
below my model (work in progress) for reference
 public class Cart
    {
        public int CartId { get; set; }
        public List<Order> Orders { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public CartStatus Status { get; set; }
        public enum CartStatus
        {
            Open = 1,
            Confirmed = 2,
            Shipped = 3,
            Received = 4
        }
    }
