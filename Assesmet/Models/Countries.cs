using System.ComponentModel.DataAnnotations.Schema;

namespace Assesmet.Models
{
    [Table("COUNTRIES", Schema = "ATOS")]
    public class Countries : Base
    {
        public string Capital { get; set; }
        public int Population { get; set; }
        public int LanguageId { get; set; }
    }
}