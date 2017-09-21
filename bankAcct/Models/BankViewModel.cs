using System.ComponentModel.DataAnnotations;

namespace BankAccts.Models
{
    public class BankViewModel : BaseEntity
    {
        [Display(Name="Deposit/Withdraw")]
        [Required]
        public float Amount { get; set; }
    }
}