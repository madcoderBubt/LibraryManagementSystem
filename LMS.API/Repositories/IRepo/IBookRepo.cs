using LMS.Shared.DataModel;

namespace LMS.API.Repositories
{
    public interface IBookRepo
    {
        public List<Books> GetBooks();
        public Books GetBook(int BookId);
        public Task<bool> DeleteBook(int BooksId);
        public Task<bool> AddOrEditBook(Books Books);
    }
}
