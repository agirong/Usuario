using System;
using System.Collections.Generic;

namespace Usuario.WebApi.Entities;

public partial class Usuario
{
    public decimal Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Contrasena { get; set; }

    public bool? Estado { get; set; }
}
