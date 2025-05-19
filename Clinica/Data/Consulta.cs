using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Data
{
    public class Consulta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El motivo es obligatorio")]
        [StringLength(200, ErrorMessage = "El motivo no puede exceder los 200 caracteres")]
        public string? Motivo { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        [Required(ErrorMessage = "La hora es obligatoria")]
        [Column(TypeName = "time")]
        [DataType(DataType.Time)]
        public TimeSpan? Hora { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un doctor")]
        public int? DoctorId { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un paciente")]
        public int PacienteId { get; set; }
        virtual public Doctor? Doctor { get; set; }
        virtual public Paciente? Paciente { get; set; }
    }
}
