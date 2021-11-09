using System;
using System.Collections.Generic;

#nullable disable

namespace StuManagement.Models
{
    public partial class Message
    {
        public int MessagesId { get; set; }
        public string Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? EventId { get; set; }
        public string UserId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
