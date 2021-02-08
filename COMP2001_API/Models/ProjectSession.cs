using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class ProjectSession
    {
        public int SessionId { get; set; }
        public int? UserId { get; set; }
        public DateTime SessionDate { get; set; }
        public bool? SessionStatus { get; set; }
        public string SessionToken { get; set; }

        public virtual ProjectUser User { get; set; }
    }
}
