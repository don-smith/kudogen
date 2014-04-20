using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudogen.Model
{
    public class TeamMember
    {
        public TeamMember()
        {
            IsAdmin = false;
            IsApproved = false;
        }
        
        public int Id { get; set; }

        public string Photo { get; set; }

        [StringLength(50, MinimumLength=1)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
