using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class userSucces
    {
        [Key]
        public int idUserSucces { get; set; } 

        // Relation avec users
        public int idUser { get; set; } // Clé étrangère pour l'utilisateur
        [ForeignKey("idUser")]
        public users User { get; set; } // Propriété de navigation vers la table "users"
        
        // Relation avec le succes
        public int idSucces { get; set; } // Clé étrangère relié à succes
        [ForeignKey("idSucces")]
        public succes Succes { get; set; } // Propriété de navigation vers la table "succes"
    }
}
