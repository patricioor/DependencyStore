namespace DependencyStore.Services
{
    public class SecondaryService : IService
    {
        private readonly PrimaryService _primaryService;

        public SecondaryService(PrimaryService? primaryService)
            => _primaryService = primaryService;
        
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
