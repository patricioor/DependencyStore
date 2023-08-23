namespace DependencyStore.Services
{
    public class PrimaryService : IService
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
