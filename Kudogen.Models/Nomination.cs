using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudogen.Model
{
    public class Nomination
    {
        public int Id { get; set; }

        public int AwardId { get; set; }
        public int NominatorId { get; set; }
        public int NominateeId { get; set; }

        [Required]
        public string BecauseText { get; set; }

        public DateTime DateSubmitted { get; set; }

        public bool ?IsWinner { get; set; }
    }
}
