namespace WebApplication1.Dtos
{
    public class OrderExtendDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
