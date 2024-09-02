using System.ComponentModel.DataAnnotations;

namespace Day_6.Helpers
{
    public class ManufactureDateLimit:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateOnly date = (DateOnly)value;

            if (date.Day <= DateOnly.FromDateTime(DateTime.Now).Day) 
            {
                return true;
            }
            return false;
        }
    }
}
