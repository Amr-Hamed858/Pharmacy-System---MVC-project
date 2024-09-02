using Day_6.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Day_6.Models
{
	public class Drug
	{
        public int ID { get; set; }


        [Required(ErrorMessage ="Please enter the drug name")]
        [MaxLength(50,ErrorMessage ="The maximum length is 50")]
        
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter the manufacture date.")]
        [DataType(DataType.Date)]
        [ManufactureDateLimit(ErrorMessage ="The insreted manufacture date can't be in the future")]
        public DateOnly ManufactureDate { get; set; }


        [Required(ErrorMessage = "Please enter the expiry date.")]
        [DataType(DataType.Date)]
        [ExpiryDateLimit(ErrorMessage ="The inserted expiry date can't be in the past")]
        public DateOnly ExpiryDate { get; set; }

        public string Image { get; set; }


        [Required(ErrorMessage ="Please select a company")]
        public int CompanyID { get; set; }

        public Company Company { get; set; }




    }
}
