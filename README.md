# Sistema de Inventario de Productos

Aplicación de escritorio desarrollada en C# y .NET con Avalonia UI y SQLite mediante ADO.NET. Permite registrar y administrar productos de un inventario.

## 1\. Información general

* **Proyecto:** Sistema de Inventario de Productos
* **Estudiante:** \[Escribe tu nombre]
* **Descripción:** Aplicación de escritorio para llevar el control de productos, categorías, precios y cantidades disponibles.
* **Necesidad que resuelve:** Facilita el registro y consulta de productos sin tener que llevar la información manualmente.
* **Objetivo:** Desarrollar una aplicación sencilla que permita administrar un inventario y conservar los datos en una base de datos.

## 2\. Funcionalidades

* Registrar productos.
* Consultar los productos registrados.
* Buscar productos por nombre.
* Modificar los datos de un producto seleccionado.
* Eliminar productos.
* Validar los campos antes de guardar.
* Mostrar el total de productos y las unidades existentes.
* Guardar la información en SQLite para conservarla al cerrar el programa.

## 3\. Tecnologías utilizadas

* C#
* .NET 10
* Avalonia UI 12.1.6
* ADO.NET
* Microsoft.Data.Sqlite 10.0.15
* SQLite

## 4\. Estructura del proyecto

```text
SistemaInventarioProductos/
├── Data/
│   ├── DbConexion.cs
│   └── ProductoDAO.cs
├── Models/
│   └── Producto.cs
├── Services/
│   └── ProductoServicio.cs
├── Views/
│   ├── MainWindow.axaml
│   └── MainWindow.axaml.cs
├── database/
│   └── crear\_base\_datos.sql
├── evidencias/
├── App.axaml
├── App.axaml.cs
├── Program.cs
├── SistemaInventarioProductos.csproj
├── .gitignore
└── README.md
```

### Clases principales

* **Producto:** representa cada producto y contiene sus propiedades: Id, Nombre, Categoria, Precio, Cantidad y Descripcion.
* **DbConexion:** crea la carpeta de almacenamiento, establece la conexión con SQLite y crea la tabla si todavía no existe.
* **ProductoDAO:** contiene las consultas SQL para registrar, consultar, buscar, actualizar y eliminar productos.
* **ProductoServicio:** valida los datos y comunica la interfaz con las operaciones de acceso a datos.
* **MainWindow:** muestra la interfaz y contiene los eventos de los botones y controles.

### Aplicación de POO

Se utiliza encapsulamiento mediante propiedades y separación de responsabilidades. Cada clase tiene una función concreta. La interfaz no ejecuta directamente las consultas SQL: utiliza la clase de servicio, que valida la información y llama a la clase DAO.

## 5\. Instalación de dependencias

Se necesita tener instalado el SDK de .NET 10.

1. Descargar o clonar el repositorio desde GitHub.
2. Abrir una terminal dentro de la carpeta del proyecto.
3. Restaurar los paquetes:

```bash
dotnet restore
```

Los paquetes Avalonia y Microsoft.Data.Sqlite están declarados en el archivo `.csproj`, por lo que se descargan al restaurar el proyecto.

## 6\. Ejecución del programa

Desde la carpeta donde se encuentra `SistemaInventarioProductos.csproj`, ejecutar:

```bash
dotnet run
```

La primera ejecución crea automáticamente la carpeta de datos y la tabla `Productos`.

## 7\. Base de datos

La aplicación utiliza SQLite. La base de datos se llama `inventario.db` y se genera automáticamente en la carpeta de datos de la aplicación del usuario:

* **Windows:** `%LOCALAPPDATA%\\\\SistemaInventarioProductos\\\\inventario.db`

La tabla `Productos` contiene los siguientes campos:

|Campo|Tipo|Descripción|
|-|-|-|
|Id|INTEGER|Identificador autoincremental|
|Nombre|TEXT|Nombre del producto|
|Categoria|TEXT|Categoría|
|Precio|REAL|Precio del producto|
|Cantidad|INTEGER|Unidades disponibles|
|Descripcion|TEXT|Información adicional|

La conexión se encuentra en `Data/DbConexion.cs`. Las operaciones CRUD están en `Data/ProductoDAO.cs` y se ejecutan con `Microsoft.Data.Sqlite`, utilizando comandos parametrizados.

No es necesario crear la base de datos manualmente. La aplicación ejecuta la instrucción `CREATE TABLE IF NOT EXISTS` al iniciar.

## 8\. Evidencias de funcionamiento

Guardar las capturas reales de las pruebas dentro de la carpeta `evidencias/`.

Se deben incluir, como mínimo:

1. **Registro:** formulario con un producto registrado y visible en la lista.
2. **Consulta:** lista de productos almacenados.
3. **Actualización:** producto modificado y cambio visible.
4. **Eliminación:** producto eliminado y ausencia en la lista.
5. **Validación:** mensaje mostrado al ingresar información incorrecta.
6. **Persistencia:** cerrar y abrir nuevamente la aplicación y comprobar que los registros siguen disponibles.

Cada imagen debe tener un nombre descriptivo y una breve explicación. No se incluyen capturas simuladas; deben tomarse al ejecutar el programa.

## 9\. Problemas encontrados y soluciones

> Completar esta sección después de ejecutar y probar el proyecto. Escribir una dificultad que realmente se haya presentado, qué la ocasionó y cómo se solucionó.

Ejemplo de redacción para adaptar si efectivamente ocurre: durante la conexión con SQLite fue necesario revisar la ruta de almacenamiento de la base de datos. Se ajustó la creación de la carpeta antes de abrir la conexión, para evitar errores cuando el archivo todavía no existía.

## 10\. Pruebas funcionales

|Prueba|Acción|Resultado esperado|
|-|-|-|
|Registro|Agregar un producto|Se guarda y aparece en la lista|
|Consulta|Abrir la aplicación|Se muestran los productos guardados|
|Actualización|Modificar un producto|Se reflejan los cambios|
|Eliminación|Eliminar un producto|Desaparece de la lista|
|Validación|Ingresar precio o cantidad incorrectos|Se muestra un mensaje|
|Persistencia|Cerrar y volver a abrir|Los productos siguen guardados|

## 11\. Autor

Luis David Múnera Pérez

Proyecto académico desarrollado para aplicar Programación Orientada a Objetos, interfaces gráficas con Avalonia UI y persistencia de datos mediante ADO.NET y SQLite.

