using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DataModel
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [AllowNull]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly RegistrationDate { get; set; }
    }
}
