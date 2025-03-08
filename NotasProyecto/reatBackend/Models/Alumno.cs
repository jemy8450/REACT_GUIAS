using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace reatBackend.Models;

public partial class Alumno
{
    public int Id { get; set; }
    [Required]
    public string Dni { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Edad { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
