using LMS.API.Data;
using LMS.Shared.DataModel;

namespace LMS.API.Repositories.Repo
{
    internal class BookRepo : IBookRepo
    {
        private readonly AppDBContext _dbContext;

        public BookRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        Task<bool> IBookRepo.AddOrEditBook(Books Books)
        {
            throw new NotImplementedException();
        }

        Task<bool> IBookRepo.DeleteBook(int BooksId)
        {
            throw new NotImplementedException();
        }

        Books IBookRepo.GetBook(int BookId)
        {
            throw new NotImplementedException();
        }

        List<Books> IBookRepo.GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
