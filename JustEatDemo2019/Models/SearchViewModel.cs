using System.ComponentModel.DataAnnotations;

namespace JustEatDemo2019.Models
{
    public class SearchViewModel
    {

        [Required(ErrorMessage = "Please enter a valid Outcode")]
        public string Outcode { get; set; }

         
    }
}