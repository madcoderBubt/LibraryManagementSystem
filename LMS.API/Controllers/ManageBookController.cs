using LMS.API.Repositories;
using LMS.Shared.DataModel;
using LMS.Shared.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageBookController : ControllerBase
    {
        private readonly IBorrowedBook manageBookRepo;

        public ManageBookController(IBorrowedBook manageBookRepo)
        {
            this.manageBookRepo = manageBookRepo;
        }

        [HttpPut("Borrowd")]
        public async Task<ActionResult> BorrowedBook(BorrowdBooks borrowd)
        {
            var result = await manageBookRepo.BookBorrowd(borrowd);
            return result ? Ok() : StatusCode(StatusCodes.Status304NotModified);
        }
        [HttpPut("Returnd")]
        public async Task<ActionResult> ReturnedBook(int bookId)
        {
            var result = await manageBookRepo.BookReturnd(new() {BookId= bookId });
            return result ? Ok() : StatusCode(StatusCodes.Status304NotModified);
        }
        [HttpGet("BorrowdHistory")]
        public ActionResult<List<BorrowHistoryModel>> BorrowdHistory()
        {
            return manageBookRepo.GetBorrowdBookList();
        }
        [HttpGet("BorrowdHistory/{id}")]
        public ActionResult<List<BorrowHistoryModel>> BorrowdHistory(int id)
        {
            return manageBookRepo.GetBorrowdBooks(id);
        }
        [HttpGet("BorrowdHistory/Book/{bookId}")]
        public ActionResult<List<BorrowHistoryModel>> BorrowdHistoryByBook(int bookId)
        {
            return manageBookRepo.GetBorrowdListByBook(bookId);
        }
        [HttpGet("BorrowdHistory/Member/{memberId}")]
        public ActionResult<List<BorrowHistoryModel>> BorrowdHistoryByMember(int memberId)
        {
            return manageBookRepo.GetBorrowdBooksByMember(memberId);
        }
        [HttpGet("BorrowdHistory/Available")]
        public ActionResult<List<BorrowHistoryModel>> AvailableBooks()
        {
            return manageBookRepo.NotReturnedList();
        }
        [HttpGet("BorrowdHistory/DueBooks")]
        public ActionResult<List<BorrowHistoryModel>> DueBooks()
        {
            return manageBookRepo.NotReturnedList();
        }
        [HttpGet("BorrowdHistory/OverDues")]
        public ActionResult<List<BorrowHistoryModel>> OverDues(int w=0, int m=0)
        {
            if (w == 0 && m == 0)
                return manageBookRepo.NotReturnedListByWeeks(1);
            else if (w > 0)
                return manageBookRepo.NotReturnedListByWeeks(w);
            else if (m > 0)
                return manageBookRepo.NotReturnedListByMonths(m);
            else
                return StatusCode(StatusCodes.Status400BadRequest, manageBookRepo.NotReturnedList());
        }
    }
}
