using LMS.Shared.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.ViewModel
{
    public class BorrowHistoryModel : BorrowdBooks
    {
        public string BookTitle { get; set; }
        public string BookISBN { get; set; }
        public string MemberFullName { get; set; }
        public string MemberContact { get; set; }
    }
}
