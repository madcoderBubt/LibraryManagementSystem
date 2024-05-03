using LMS.Shared.DataModel;

namespace LMS.API.Repositories
{
    public interface IAuthorRepo
    {
        public List<Authors> GetAuthors();
        public Authors GetAuthor(int authorId);
        public Task<bool> DeleteAuthor(int authorId);
        public Task<bool> AddOrEditAuthor(Authors authors); //if has id edit else add
    }
}
