namespace MongoDBAPIFrameWork.Models
{
    public interface ISettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
