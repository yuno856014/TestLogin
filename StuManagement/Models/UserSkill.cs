using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class UserSkill
    {
        public string UserId { get; set; }
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
    }
}
