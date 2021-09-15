using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoLearnServer.Model
{
    public class PartModel : Model
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public PartModel()
        {
            ModelType = ModelType.Part;
        }
        
        public string Name { get; set; }
        public ModelType ModelType { get; set; }
        public string StockNumber { get; set; }
        public string Description { get; set; }
        public List<PartModel> PartsList { get; set; }
        public List<AssemblyModel> SubAssemblyList { get; set; }
    }

    public interface Model
    {
        [BsonElement("Name")]
        string Name { get; set; }
        
        ModelType ModelType { get; set; }

        string StockNumber { get; set; }

        string Description { get; set; }

        public List<PartModel> PartsList { get; set; }
        public List<AssemblyModel> SubAssemblyList { get; set; }
    }

    public enum ModelType
    {
        Part = 1,
        Assembly = 2,
    }
}
