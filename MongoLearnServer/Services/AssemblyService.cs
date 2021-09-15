using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoLearnServer.Model;

namespace MongoLearnServer.Services
{
    public class AssemblyService
    {
        /// <summary>
        /// Variável para armazenar a coleção
        /// </summary>
        private readonly IMongoCollection<AssemblyModel> _assembles;
        private readonly IMongoCollection<PartModel> _parts;

        /// <summary>
        /// Construtor da classe com injeção
        /// </summary>
        /// <param name="settings"></param>
        public AssemblyService(IModelsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _assembles = database.GetCollection<AssemblyModel>(settings.PartCollectionName);
            _parts = database.GetCollection<PartModel>(settings.PartCollectionName);
        }

        /// <summary>
        /// Retorna a lista de parts
        /// </summary>
        /// <returns></returns>
        public List<AssemblyModel> Get()
        {
            var resultAssys =  _assembles.Find(assy => true).ToList().Where(a => a.ModelType == ModelType.Assembly).ToList();
            
            return resultAssys;
        }

        /// <summary>
        /// Retornar uma Part pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssemblyModel Get(string id) => _assembles.Find(assy => assy.Id == id).FirstOrDefault();

        /// <summary>
        /// Cria uma Part
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public AssemblyModel Create(AssemblyModel assembly)
        {
            _parts.InsertMany(assembly.PartsList);
            _assembles.InsertOne(assembly);
            return assembly;
        }

        /// <summary>
        /// Atualiza uma part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedPartModel"></param>
        public void Update(string id, AssemblyModel updatedPartModel) =>
            _assembles.ReplaceOne(part => part.Id == id, updatedPartModel);

        /// <summary>
        /// Deleta uma Part
        /// </summary>
        /// <param name="partToDelete"></param>
        public void Delete(AssemblyModel partToDelete) => _assembles.DeleteOne(part => part.Id == partToDelete.Id);
        
        /// <summary>
        /// Deleta uma part pelo ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id) => _assembles.DeleteOne(part => part.Id == id);


    }
}
