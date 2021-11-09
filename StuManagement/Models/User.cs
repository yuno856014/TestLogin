using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Events = new HashSet<Event>();
            Messages = new HashSet<Message>();
            UserSchoolYears = new HashSet<UserSchoolYear>();
            UserSkills = new HashSet<UserSkill>();
        }
        public string StudentCode { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? RoleId { get; set; }
        public string Avatar { get; set; }
        public int? ScholasticId { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserSchoolYear> UserSchoolYears { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
