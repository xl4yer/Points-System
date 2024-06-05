namespace Points_System.Models
{
    public class items
    {
        public string itemID { get; set; } = "";
        public byte[]? photo { get; set; }
        public string itemname { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
    }
}
