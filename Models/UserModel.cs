using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stuffed.Models{
    [Table("t_users")]
    public class UserModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Column("first_name")]
        public string? first_name {get;set;}

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Column("last_name")]
        public string? last_name {get;set;}

         [Required(ErrorMessage = "El campo es obligatorio")]
        [Column("fecha")]
        [DataType(DataType.Date)]
        public DateTime fecha {get; set;}

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Column("libro")]
        public int libro {get; set;}

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Column("pagina")]
        public int pagina {get; set;}

        [NotMapped]
        public string? Mensaje { get; set; }
}
}