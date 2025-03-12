using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parcia1.Models
{
    public class Students : BaseModel
    {
        #region Propiedades
        [Key]
        public int IdStudent { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [StringLength(50, ErrorMessage = "El correo no puede tener más de 50 caracteres")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [NotNull]
        [Required(ErrorMessage = "El carnet es requerido")]
        public string Carnet { get; set; }

        [Required(ErrorMessage = "La cantidad de materias es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de materias debe ser mayor a 5")]
        public int? CantidadMaterias { get; set; }

        [Required(ErrorMessage = "El ciclo es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ciclo debe ser mayor a 0")]
        public int? Ciclo { get; set; }

        // Nueva propiedad para el número de celular
        [Required(ErrorMessage = "El número de celular es requerido")]
        [Phone(ErrorMessage = "El número de celular no es válido")]
        [StringLength(15, ErrorMessage = "El número de celular no puede tener más de 15 caracteres")]
        public string CellPhone { get; set; }

        [NotMapped]
        public string NombreCompleto => $"{Name} {LastName}";

        #endregion Propiedades

        #region Constructor
        public Students()
        {
            BirthDate = DateTime.Now.Date;
            IsActive = true;
            Created = DateTime.Now;
            CreatedBy = "ADMIN";
        }

        public Students(string name, string lastName, string email, DateTime birthDate, int cellPhone)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            CellPhone = CellPhone;
            
        }
        #endregion Constructor

        #region Funciones
        public bool EsMayorDeEdad()
        {
            int edad = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateTime.Now.AddYears(-edad)) edad--;
            return edad >= 18;
        }
        #endregion Funciones
    }
}
