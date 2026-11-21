namespace SistemaInventarioProductos.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public string Descripcion { get; set; }

    public Producto()
    {
        Nombre = "";
        Categoria = "";
        Descripcion = "";
    }

    public Producto(string nombre, string categoria, decimal precio, int cantidad, string descripcion)
    {
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Cantidad = cantidad;
        Descripcion = descripcion;
    }
}
