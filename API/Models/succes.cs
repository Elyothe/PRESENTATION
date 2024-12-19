using Org.BouncyCastle.Asn1.Cmp;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class succes
    {
        [Key]
        public int idSucces { get; set; }

        public int pointrequired { get; set; }

        [Required, MaxLength(100)]
        public string libelleSucces { get; set; }

        // Ajout de la relation inverse
        public ICollection<userSucces> UserSucces { get; set; } // Relation avec les succès des utilisateurs
    }
}

