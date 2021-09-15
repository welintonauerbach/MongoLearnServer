namespace MongoLearnServer.DatabaseSettings
{
    public class ModelsDatabaseSettings : IModelsDatabaseSettings
    {
        public string PartCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IModelsDatabaseSettings
    {
        string PartCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
