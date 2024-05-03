using LMS.API.Data;
using LMS.Shared.DataModel;
using LMS.Shared.ViewModel;

namespace LMS.API.Repositories.Repo
{
    internal class BorrowedRepo : IBorrowedBook
    {
        private readonly AppDBContext _dbContext;

        public BorrowedRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> BookBorrowd(BorrowdBooks borrowd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BookReturnd(BorrowdBooks borrowd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BorrowdStatusChange(BorrowdBooks borrowd)
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> GetBorrowdBookList()
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> GetBorrowdBooks(int MemberId)
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> GetBorrowdBooksByMember(int MemberId)
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> GetBorrowdListByBook(int BookId)
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> NotReturnedList()
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> NotReturnedListByMonths(int months)
        {
            throw new NotImplementedException();
        }

        public List<BorrowHistoryModel> NotReturnedListByWeeks(int weeks)
        {
            throw new NotImplementedException();
        }
    }
}
