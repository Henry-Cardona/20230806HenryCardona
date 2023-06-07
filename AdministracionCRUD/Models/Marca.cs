using System;
using System.Collections.Generic;

namespace AdministracionCRUD.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public decimal? Exactitud { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
