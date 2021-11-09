using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            UserSchoolYears = new HashSet<UserSchoolYear>();
        }

        public int SchoolYearId { get; set; }
        public string SchoolYearName { get; set; }

        public virtual ICollection<UserSchoolYear> UserSchoolYears { get; set; }
    }
}
