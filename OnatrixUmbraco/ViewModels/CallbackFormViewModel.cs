using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnatrixUmbraco.ViewModels;

public class CallbackFormViewModel
{
    [MaxLength(50)]
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;
    
    [MaxLength(150)]
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email need to be formatted as <name@domain.com>")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Phone is required")]
    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^(?:\+46\s?|0)\d(?:[\s]?\d){8,11}$", ErrorMessage = "Phonenumber needs to be formatted as:\n+46 701231234 OR\n0701231234")]
    public string Phone { get; set; } = null!;
    
    [Required(ErrorMessage = "Please select an option")]
    public string SelectedOption { get; set; } = null!;

    
    [BindNever]
    public IEnumerable<string> Options { get; set; } = [];
}