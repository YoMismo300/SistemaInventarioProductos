using SistemaInventarioProductos.Data;
using SistemaInventarioProductos.Models;

namespace SistemaInventarioProductos.Services;

public class ProductoServicio
{
    private readonly ProductoDAO productoDAO;

    public ProductoServicio()
    {
        productoDAO = new ProductoDAO();
    }

    public List<Producto> ListarProductos()
    {
        return productoDAO.Listar();
    }

    public List<Producto> BuscarProductos(string nombre)
    {
        return productoDAO.Buscar(nombre);
    }

    public void RegistrarProducto(Producto producto)
    {
        ValidarProducto(producto);
        productoDAO.Agregar(producto);
    }

    public void ModificarProducto(Producto producto)
    {
        if (producto.Id <= 0)
        {
            throw new ArgumentException("Selecciona un producto para modificar.");
        }

        ValidarProducto(producto);
        productoDAO.Actualizar(producto);
    }

    public void EliminarProducto(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Selecciona un producto para eliminar.");
        }

        productoDAO.Eliminar(id);
    }

    private void ValidarProducto(Producto producto)
    {
        if (string.IsNullOrWhiteSpace(producto.Nombre))
        {
            throw new ArgumentException("El nombre del producto es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(producto.Categoria))
        {
            throw new ArgumentException("La categoría es obligatoria.");
        }

        if (producto.Precio <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor que cero.");
        }

        if (producto.Cantidad < 0)
        {
            throw new ArgumentException("La cantidad no puede ser negativa.");
        }
    }
}
