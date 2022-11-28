using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Scout.Infrastructure.Entities;

namespace Scout.Infrastructure.EntityDataModels
{
    public class ScoutEntityDataModel
    {
        public IEdmModel GetEntityDataModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Scout";
            builder.ContainerName = "ScoutContainer";

            builder.EntitySet<ScoutEntity>("Scouts");

            return builder.GetEdmModel();
        }
    }
}