namespace DependencyStore.Services
{
    public class TertiaryService : IService
    {
        readonly PrimaryService _primaryService;
        readonly SecondaryService _secondaryService;
        readonly SecondaryService _secondaryServiceNewInstance;

        public TertiaryService(SecondaryService? secondaryServiceNewInstance, SecondaryService? secondaryService, PrimaryService? primaryService)
        {
            _primaryService = primaryService;
            _secondaryService = secondaryService;
            _secondaryServiceNewInstance = secondaryServiceNewInstance;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PrimaryServiceId => _primaryService.Id;
        public Guid SecondaryServiceId => _secondaryService.Id;
        public Guid SecondaryServiceNewInstanceId => _secondaryServiceNewInstance.Id;
    }
}
