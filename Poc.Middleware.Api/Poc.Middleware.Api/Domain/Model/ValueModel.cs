namespace Poc.Middleware.Api.Domain.Model
{
    public class ValueModel
    {
        public Guid GuiId { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
