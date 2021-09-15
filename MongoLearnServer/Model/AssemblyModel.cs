using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoLearnServer.Model
{
    public class AssemblyModel : Model
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public AssemblyModel()
        {
            PartsList = new List<PartModel>();
            SubAssemblyList = new List<AssemblyModel>();
            ModelType = ModelType.Assembly;
        }

        public string Name { get; set; }
        public ModelType ModelType { get; set; }
        public string StockNumber { get; set; }
        public string Description { get; set; }
        
        public List<PartModel> PartsList { get; set; }
        public List<AssemblyModel> SubAssemblyList { get; set; }
        
        public void SetParts(List<PartModel> parts)
        {
            PartsList.AddRange(parts);
        }

        public void AddPart(PartModel part)
        {
            PartsList.Add(part);
        }
    }
}
