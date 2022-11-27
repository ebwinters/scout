namespace Scout.Infrastructure
{
    public class CosmosDbContainerSettings
    {
        public string DatabaseName { get; set; } = "scoutDb";
        public string ContainerName { get; set; } = "scouts";
    }
}