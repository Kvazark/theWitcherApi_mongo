namespace Mongo_TheWitcherApi.Models
{
    public class HuntingDatabaseSettings 
    {
        public string ConnectionString { get; set; } = null!;
        public string HuntingCollectionName { get; set; } = null!;
        public string DatabaseName { get; set; }= null!;
    }
}