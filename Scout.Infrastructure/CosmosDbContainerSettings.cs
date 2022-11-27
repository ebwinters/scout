namespace Scout.Infrastructure
{
    public class CosmosDbContainerSettings
    {
        public string AccountEndpoint { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = "scoutDb";
        public string ContainerName { get; set; } = "scouts";
    }
}