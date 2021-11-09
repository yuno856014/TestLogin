using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class Skill
    {
        public Skill()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Style { get; set; }
        public string Tags { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
