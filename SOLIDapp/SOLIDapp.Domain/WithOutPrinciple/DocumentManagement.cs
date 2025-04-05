namespace SOLIDapp.Domain.WithOutPrinciple
{
    public interface IDocumentManagement
    {
        void CreateDocument(string content);
        string ReadDocument(int id);
        void UpdateDocument(int id, string content);
        void DeleteDocument(int id);
    }
    public class ReadOnlyUser : IDocumentManagement
    {
        public void CreateDocument(string content)
        {
            throw new NotImplementedException("Read-only users cannot create documents.");
        }
        public string ReadDocument(int id)
        {
            // Implementation to read the document.
            return "Sample document content.";
        }
        public void UpdateDocument(int id, string content)
        {
            throw new NotImplementedException("Read-only users cannot update documents.");
        }
        public void DeleteDocument(int id)
        {
            throw new NotImplementedException("Read-only users cannot delete documents.");
        }
    }
}