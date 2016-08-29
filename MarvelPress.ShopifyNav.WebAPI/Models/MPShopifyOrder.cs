namespace MarvelPress.ShopifyNav.WebAPI.Models
{
    public class MPShopifyOrder
    {
        public string OrderId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string ProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string TrackingNumber { get; set; }
    }
}