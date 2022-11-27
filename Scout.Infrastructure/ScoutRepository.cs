using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Scout.Infrastructure
{
    public class ScoutRepository
    {
        private CosmosClient _client;
        private CosmosDbContainerSettings _settings;

        public ScoutRepository(CosmosClient cosmosClient, CosmosDbContainerSettings settings)
        {
            _client= cosmosClient;
            _settings= settings;
        }

        public async Task<IEnumerable<ScoutDbo>> getScouts()
        {
            Database database = await _client.CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);
            Container container = database.GetContainer(_settings.ContainerName);

            var query = container.GetItemQueryIterator<ScoutDbo>("SELECT * FROM c");
            List<ScoutDbo> scouts = new List<ScoutDbo>();
            while (query.HasMoreResults)
            {
                FeedResponse<ScoutDbo> result = await query.ReadNextAsync();
                foreach (var item in result)
                {
                    scouts.Add(item);
                }
            }
            return scouts;
        }

        public async Task createScout(ScoutDbo scout)
        {
            Database database = await _client.CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);
            Container container = database.GetContainer(_settings.ContainerName);

            var query = await container.CreateItemAsync<ScoutDbo>(scout);
        }
    }
}
