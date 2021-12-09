using System.ComponentModel.DataAnnotations;

namespace Assesmet.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}