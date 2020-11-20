using System.ComponentModel.DataAnnotations;

namespace TBureck.Test.CheckBoxes.Models
{
    
    public class CheckBoxTestModel
    {
        
        [Required]
        public string MandatoryField { get; set; }
        public string OptionalField { get; set; }
        [Required]
        public bool Accept { get; set; }
    }
}