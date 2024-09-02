using Day_6.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Day_6.Models
{
	public class Company
	{
	
        public int ID { get; set; }

		[Required(ErrorMessage ="Please enter the company name")]
		[MaxLength(20)]
		[UniqueCompanyName]
		public string Name { get; set; }

		public ICollection<Drug> Drugs { get; set; } = new HashSet<Drug>();
    }
}
