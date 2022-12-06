namespace Pharmacy2.Models
{
    public class CartItem
    {
        public long DrugId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        { 
            get { return Quantity * Price; }
        }
        public string Image { get; set; }
        public CartItem()
        {
        }
        public CartItem(Drug drug)
        {
            DrugId = drug.Id;
            DrugName = drug.Name;
            Price = drug.Price;
            Quantity = 1;
            Image = drug.Image;
        }




    }
}
