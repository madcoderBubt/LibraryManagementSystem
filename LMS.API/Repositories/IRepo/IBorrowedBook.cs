using LMS.Shared.DataModel;
using LMS.Shared.ViewModel;

namespace LMS.API.Repositories
{
    public interface IBorrowedBook
    {
        public List<BorrowHistoryModel> GetBorrowdBookList();
        public List<BorrowHistoryModel> GetBorrowdBooks(int borrowdId);
        public List<BorrowHistoryModel> GetBorrowdBooksByMember(int MemberId);
        public List<BorrowHistoryModel> GetBorrowdListByBook(int BookId);

        public Task<bool> BookBorrowd(BorrowdBooks borrowd);
        public Task<bool> BookReturnd(BorrowdBooks borrowd);
        public Task<bool> BorrowdStatusChange(BorrowdBooks borrowd);

        public List<BorrowHistoryModel> NotReturnedList();
        public List<BorrowHistoryModel> NotReturnedListByWeeks(int weeks);
        public List<BorrowHistoryModel> NotReturnedListByMonths(int months);
    }
}
