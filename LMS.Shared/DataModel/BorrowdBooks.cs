using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS.Shared.DataModel
{
    public class BorrowdBooks
    {
        [Key]
        public int BorrowId { get; set; }
        public DateOnly BorrowDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public BorrowStatus Status { get; set; }
        public int DueCharged { get; set; }

        [ForeignKey(nameof(Members))]
        public int MemberId { get; set; }
        [JsonIgnore]
        public Members Members { get; set; }

        [ForeignKey(nameof(Books))]
        public int BookId { get; set; }
        [JsonIgnore]
        public Books Books { get; set; }
    }
    public enum BorrowStatus
    {
        Borrowed = 1,
        Returned = 2,
        Overdue = 3
    }
}
