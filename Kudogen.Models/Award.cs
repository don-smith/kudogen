using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kudogen.Model
{
    public class Award
    {
        public Award()
        {
            IsActive = true;
            WinnerType = WinnerTypeEnum.Everyone;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public WinnerTypeEnum WinnerType { get; set; }

        public bool IsActive { get; set; }
    }

    public enum WinnerTypeEnum
    {
        Everyone, 
        Random,
        Vote
    }
}
