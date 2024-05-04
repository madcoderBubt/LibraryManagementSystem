using LMS.API.Data;
using LMS.Shared.DataModel;
using LMS.Shared.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Repositories.Repo
{
    internal class BorrowedRepo : IBorrowedBook
    {
        private readonly AppDBContext _dbContext;

        public BorrowedRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> BookBorrowd(BorrowdBooks borrowd)
        {
            await _dbContext.BorrowdBooks.AddAsync(borrowd);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> BookReturnd(BorrowdBooks borrowd)
        {
            var dbData = _dbContext.BorrowdBooks.FirstOrDefault(f=>f.BorrowId==borrowd.BorrowId);
            var result = 0;
            if (dbData is not null)
            {
                dbData.ReturnDate = DateOnly.FromDateTime(DateTime.Today);
                dbData.Status = BorrowStatus.Returned;
                _dbContext.BorrowdBooks.Update(dbData);
                result = await _dbContext.SaveChangesAsync();
            }
            return result > 0;
        }

        public async Task<bool> BorrowdStatusChange(BorrowdBooks borrowd)
        {
            var dbData = _dbContext.BorrowdBooks.FirstOrDefault(f => f.BorrowId == borrowd.BorrowId);
            var result = 0;
            if (dbData is not null)
            {
                if(borrowd.Status==BorrowStatus.Returned) dbData.ReturnDate = DateOnly.FromDateTime(DateTime.Today);
                dbData.Status = borrowd.Status;
                _dbContext.BorrowdBooks.Update(dbData);
                result = await _dbContext.SaveChangesAsync();
            }
            return result > 0;
        }

        public List<BorrowHistoryModel> GetBorrowdBookList()
        {
            return _dbContext.BorrowdBooks.Include("Books").Include("Members")
                .Select( (data) => new BorrowHistoryModel()
                {
                    BookId = data.BookId,
                    BookISBN = data.Books.ISBN,
                    BookTitle = data.Books.Title,
                    BorrowDate = data.BorrowDate,
                    ReturnDate = data.ReturnDate,
                    Status = data.Status,
                    DueCharged = data.DueCharged,
                    MemberId = data.MemberId,
                    MemberContact = data.Members.PhoneNumber,
                    MemberFullName = data.Members.FirstName,
                    BorrowId = data.BorrowId
                }).ToList();
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
        BorrowHistoryModel MapHistoryModel(BorrowdBooks book)
        {
            BorrowHistoryModel historyModel = (BorrowHistoryModel) book;
            //historyModel.BookTitle = book.Books.Title;
            //historyModel.BookISBN = book.Books.ISBN;
            //historyModel.MemberFullName = book.Members.FirstName+" "+book.Members.LastName;
            //historyModel.MemberContact = book.Members.PhoneNumber;
            return historyModel;
        }
    }
}
