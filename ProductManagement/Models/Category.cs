namespace ProductManagement.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string CatDesc { get; set; }
    }

    public class ProductsCategory
    {
        public int ProdId { get; set; }
        public int CatID { get; set; }
        public string ProdName { get; set; }
        public string ProdImg { get; set; }
        public string Price { get; set; }
        public string ProdDesc { get; set; }
    }
}