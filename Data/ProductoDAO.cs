using Microsoft.Data.Sqlite;
using SistemaInventarioProductos.Models;

namespace SistemaInventarioProductos.Data;

public class ProductoDAO
{
    public List<Producto> Listar()
    {
        List<Producto> productos = new List<Producto>();

        using (var conexion = DbConexion.ObtenerConexion())
        {
            conexion.Open();

            string consulta = "SELECT * FROM Productos ORDER BY Id DESC";

            using (var comando = new SqliteCommand(consulta, conexion))
            using (var lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = lector.GetInt32(0);
                    producto.Nombre = lector.GetString(1);
                    producto.Categoria = lector.GetString(2);
                    producto.Precio = Convert.ToDecimal(lector.GetDouble(3));
                    producto.Cantidad = lector.GetInt32(4);
                    producto.Descripcion = lector.IsDBNull(5) ? "" : lector.GetString(5);

                    productos.Add(producto);
                }
            }
        }

        return productos;
    }

    public List<Producto> Buscar(string nombre)
    {
        List<Producto> productos = new List<Producto>();

        using (var conexion = DbConexion.ObtenerConexion())
        {
            conexion.Open();

            string consulta = @"SELECT * FROM Productos
                                WHERE Nombre LIKE @nombre
                                ORDER BY Id DESC";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Producto producto = new Producto();

                        producto.Id = lector.GetInt32(0);
                        producto.Nombre = lector.GetString(1);
                        producto.Categoria = lector.GetString(2);
                        producto.Precio = Convert.ToDecimal(lector.GetDouble(3));
                        producto.Cantidad = lector.GetInt32(4);
                        producto.Descripcion = lector.IsDBNull(5) ? "" : lector.GetString(5);

                        productos.Add(producto);
                    }
                }
            }
        }

        return productos;
    }

    public void Agregar(Producto producto)
    {
        using (var conexion = DbConexion.ObtenerConexion())
        {
            conexion.Open();

            string consulta = @"INSERT INTO Productos
                                (Nombre, Categoria, Precio, Cantidad, Descripcion)
                                VALUES
                                (@nombre, @categoria, @precio, @cantidad, @descripcion)";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@categoria", producto.Categoria);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void Actualizar(Producto producto)
    {
        using (var conexion = DbConexion.ObtenerConexion())
        {
            conexion.Open();

            string consulta = @"UPDATE Productos SET
                                Nombre = @nombre,
                                Categoria = @categoria,
                                Precio = @precio,
                                Cantidad = @cantidad,
                                Descripcion = @descripcion
                                WHERE Id = @id";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@categoria", producto.Categoria);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("@id", producto.Id);

                comando.ExecuteNonQuery();
            }
        }
    }

    public void Eliminar(int id)
    {
        using (var conexion = DbConexion.ObtenerConexion())
        {
            conexion.Open();

            string consulta = "DELETE FROM Productos WHERE Id = @id";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
        }
    }
}
