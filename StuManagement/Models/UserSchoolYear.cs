using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class UserSchoolYear
    {
        public string UserId { get; set; }
        public int ScholYearId { get; set; }

        public virtual SchoolYear ScholYear { get; set; }
        public virtual User User { get; set; }
    }
}
