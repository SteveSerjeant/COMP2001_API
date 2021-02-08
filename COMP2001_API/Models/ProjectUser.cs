using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class ProjectUser
    {
        public ProjectUser()
        {
            ProjectPasswords = new HashSet<ProjectPassword>();
            ProjectSessions = new HashSet<ProjectSession>();
        }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<ProjectPassword> ProjectPasswords { get; set; }
        public virtual ICollection<ProjectSession> ProjectSessions { get; set; }
    }
}
