namespace Points_System.Models
{
    public class orders
    {
        public string orderID { get; set; } = "";
        public string customerID { get; set; } = "";
        public string itemID { get; set; } = "";
        public DateTime date { get; set; }
        public string fullname { get; set; } = "";
        public byte[] photo { get; set; }
        public string itemname { get; set; } = "";
        public decimal price { get; set; }
        public decimal points { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }
    }

    public class order2
    {
        public string orderID { get; set; } = "";
        public string customerID { get; set; } = "";
        public string itemID { get; set; } = "";
        public DateTime date { get; set; }
        public decimal points { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }
    }
}
