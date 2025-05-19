using System.ComponentModel.DataAnnotations;

namespace Clinica.Data
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [StringLength(100, ErrorMessage = "El correo no puede exceder los 100 caracteres")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El teléfono no es válido")]
        [Length(10, 10, ErrorMessage = "El teléfono de contener 10 dígitos")]
        public string? Telefono { get; set; }
        virtual public List<Consulta>? Consultas { get; set; }

    }
}
