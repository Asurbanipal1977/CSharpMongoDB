namespace MongoDBAPI2.Models
{
    public class PeopleSettings : ISettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}
