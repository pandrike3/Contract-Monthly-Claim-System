using System;
using System.ComponentModel.DataAnnotations;

namespace CMCS.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        public DateTime ClaimDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Status { get; set; } = "Pending"; // Default status

        public string ManagerComments { get; set; }

        public Claim()
        {
            // Optional constructor logic
        }
    }
}

