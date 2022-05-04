using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonsApi.Models
{
    public partial class Person
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? SurName { get; set; }
        [Required]
        public string? Mail { get; set; }
    }
}
