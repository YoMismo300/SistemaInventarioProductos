using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SistemaInventarioProductos.Models;
using SistemaInventarioProductos.Services;

namespace SistemaInventarioProductos.Views;

public partial class MainWindow : Window
{
    private readonly ProductoServicio productoServicio;
    private int productoSeleccionado;

    public MainWindow()
    {
        InitializeComponent();

        productoServicio = new ProductoServicio();
        productoSeleccionado = 0;

        CargarProductos();
    }

    private void CargarProductos()
    {
        List<Producto> productos = productoServicio.ListarProductos();
        listaProductos.ItemsSource = productos;

        txtTotalProductos.Text = productos.Count.ToString();
        txtTotalUnidades.Text = productos.Sum(p => p.Cantidad).ToString();
    }

    private Producto ObtenerDatosFormulario()
    {
        string nombre = txtNombre.Text?.Trim() ?? "";
        string categoria = txtCategoria.Text?.Trim() ?? "";
        string descripcion = txtDescripcion.Text?.Trim() ?? "";

        if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precio) &&
            !decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
        {
            throw new ArgumentException("Escribe un precio válido. Puedes utilizar coma o punto decimal.");
        }

        if (!int.TryParse(txtCantidad.Text, out int cantidad))
        {
            throw new ArgumentException("La cantidad debe ser un número entero.");
        }

        return new Producto(nombre, categoria, precio, cantidad, descripcion);
    }

    private void Guardar_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Producto producto = ObtenerDatosFormulario();
            productoServicio.RegistrarProducto(producto);

            MostrarMensaje("Producto registrado correctamente.");
            LimpiarFormulario();
            CargarProductos();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Actualizar_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (productoSeleccionado == 0)
            {
                throw new ArgumentException("Selecciona un producto de la lista.");
            }

            Producto producto = ObtenerDatosFormulario();
            producto.Id = productoSeleccionado;

            productoServicio.ModificarProducto(producto);

            MostrarMensaje("Producto actualizado correctamente.");
            LimpiarFormulario();
            CargarProductos();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Eliminar_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (productoSeleccionado == 0)
            {
                throw new ArgumentException("Selecciona un producto de la lista.");
            }

            productoServicio.EliminarProducto(productoSeleccionado);

            MostrarMensaje("Producto eliminado correctamente.");
            LimpiarFormulario();
            CargarProductos();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void Buscar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string busqueda = txtBuscar.Text?.Trim() ?? "";

        if (busqueda == "")
        {
            CargarProductos();
        }
        else
        {
            listaProductos.ItemsSource = productoServicio.BuscarProductos(busqueda);
        }
    }

    private void ListaProductos_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (listaProductos.SelectedItem is Producto producto)
        {
            productoSeleccionado = producto.Id;

            txtNombre.Text = producto.Nombre;
            txtCategoria.Text = producto.Categoria;
            txtPrecio.Text = producto.Precio.ToString(CultureInfo.CurrentCulture);
            txtCantidad.Text = producto.Cantidad.ToString();
            txtDescripcion.Text = producto.Descripcion;
        }
    }

    private void Limpiar_Click(object? sender, RoutedEventArgs e)
    {
        LimpiarFormulario();
        MostrarMensaje("Campos limpiados.");
    }

    private void LimpiarFormulario()
    {
        productoSeleccionado = 0;

        listaProductos.SelectedItem = null;
        txtNombre.Text = "";
        txtCategoria.Text = "";
        txtPrecio.Text = "";
        txtCantidad.Text = "";
        txtDescripcion.Text = "";

        txtNombre.Focus();
    }

    private void MostrarMensaje(string mensaje)
    {
        txtMensaje.Text = mensaje;
    }
}
