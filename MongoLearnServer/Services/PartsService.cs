using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoLearnServer.DatabaseSettings;
using MongoLearnServer.Model;

namespace MongoLearnServer.Services
{
    public class PartsService
    {
        /// <summary>
        /// Variável para armazenar a coleção
        /// </summary>
        private readonly IMongoCollection<PartModel> _parts;

        /// <summary>
        /// Construtor da classe com injeção
        /// </summary>
        /// <param name="settings"></param>
        public PartsService(IModelsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _parts = database.GetCollection<PartModel>(settings.PartCollectionName);
        }

        /// <summary>
        /// Retorna a lista de parts
        /// </summary>
        /// <returns></returns>
        public List<PartModel> Get()
        {
            var filterPart = _parts.Find(p => true).ToList().Where(p => p.ModelType == ModelType.Part).ToList();

            return filterPart;
        }

        /// <summary>
        /// Retornar uma Part pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartModel Get(string id) => _parts.Find(parts => parts.Id == id).FirstOrDefault();

        /// <summary>
        /// Cria uma Part
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public PartModel Create(PartModel part)
        {
            _parts.InsertOne(part);
            return part;
        }

        /// <summary>
        /// Atualiza uma part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedPartModel"></param>
        public void Update(string id, PartModel updatedPartModel) =>
            _parts.ReplaceOne(part => part.Id == id, updatedPartModel);

        /// <summary>
        /// Deleta uma Part
        /// </summary>
        /// <param name="partToDelete"></param>
        public void Delete(PartModel partToDelete) => _parts.DeleteOne(part => part.Id == partToDelete.Id);
        
        /// <summary>
        /// Deleta uma part pelo ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id) => _parts.DeleteOne(part => part.Id == id);


    }
}
