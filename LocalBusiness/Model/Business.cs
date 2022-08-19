using System.ComponentModel.DataAnnotations;

namespace LocalBusiness.Models
{
  public class Business
  {
    public int BusinessId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
    [Required, StringLength(10, ErrorMessage = "Only ten digits for phone number")]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
  }
}

