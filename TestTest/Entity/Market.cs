namespace TestTest.Entity
{
    public class Market
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        public List<market_protuct> nmarket_product { get; set; }
        public List<Personal> personali { get; set; }
    }
}
