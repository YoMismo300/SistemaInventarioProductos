using Microsoft.Data.Sqlite;

namespace SistemaInventarioProductos.Data;

public static class DbConexion
{
    private static readonly string Carpeta = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "SistemaInventarioProductos");

    private static readonly string RutaBaseDatos = Path.Combine(Carpeta, "inventario.db");

    public static string CadenaConexion
    {
        get
        {
            return $"Data Source={RutaBaseDatos}";
        }
    }

    public static SqliteConnection ObtenerConexion()
    {
        return new SqliteConnection(CadenaConexion);
    }

    public static void CrearBaseDatos()
    {
        Directory.CreateDirectory(Carpeta);

        using (var conexion = ObtenerConexion())
        {
            conexion.Open();

            string consulta = @"
                CREATE TABLE IF NOT EXISTS Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Categoria TEXT NOT NULL,
                    Precio REAL NOT NULL,
                    Cantidad INTEGER NOT NULL,
                    Descripcion TEXT
                );";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.ExecuteNonQuery();
            }
        }
    }
}
