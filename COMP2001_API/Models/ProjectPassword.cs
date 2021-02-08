using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class ProjectPassword
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string PasswordPrevious { get; set; }
        public string PasswordNew { get; set; }
        public DateTime PasswordDateChanged { get; set; }

        public virtual ProjectUser User { get; set; }
    }
}
