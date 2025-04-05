namespace SOLIDapp.Domain.WithPrinciple;

public interface ICreateDocument
{
    void CreateDocument(string content);
}
public interface IReadDocument
{
    string ReadDocument(int id);
}
public interface IUpdateDocument
{
    void UpdateDocument(int id, string content);
}
public interface IDeleteDocument
{
    void DeleteDocument(int id);
}
// For read-only users:
public class ReadOnlyUser : IReadDocument
{
    public string ReadDocument(int id)
    {
        // Implementation to read the document.
        return "Sample Document Content.";
    }
}
// For admin users who have all privileges:
public class AdminUser : ICreateDocument, IReadDocument, IUpdateDocument, IDeleteDocument
{
    string[] documents = new string[2] ;
    public void CreateDocument(string content)
    {
        documents[1] = content;
    }
    public string ReadDocument(int id)
    {
        // Implementation to read the document.
        return documents[id];
    }
    public void UpdateDocument(int id, string content)
    {
        documents[id] = content;
    }
    public void DeleteDocument(int id)
    {
        documents[id] = string.Empty;        
    }
}