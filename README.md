# Personalización de DataGridView (.NET Core 10)

Este es un proyecto de Windows Forms desarrollado en **.NET Core 10** que demuestra cómo personalizar visual y funcionalmente un control **DataGridView**. La aplicación se conecta a una base de datos SQL para listar, organizar y mostrar la información de una tabla de productos.

##  Características
* **Personalización Avanzada:** Modificación de estilos, colores de filas (cebra), fuentes y encabezados del DataGridView.
* **Conexión a Base de Datos:** Integración limpia con SQL Server utilizando un Connection String configurable.
* **Moderna Tecnología:** Desarrollado utilizando las últimas características de **.NET Core 10**.

##  Requisitos e Instalación

### Prerrequisitos
* Visual Studio 2025 o superior (con soporte para .NET 10).
* .NET 10 SDK instalado.
* SQL Server (local o remoto).

### Base de Datos
El proyecto requiere una tabla llamada `Productos`. Puedes crearla ejecutando el siguiente script en tu base de datos:

```sql
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    Categoria VARCHAR(50)
);
```

##  Configuración

Para conectar la aplicación a tu base de datos, debes actualizar la cadena de conexión (**Connection String**) en el archivo de configuración correspondiente de tu proyecto (por ejemplo, `appsettings.json` o directamente en tu clase de conexión):

```csharp
string connectionString = "Server=TU_SERVIDOR;Database=TU_BASE_DATOS;Trusted_Connection=True;TrustServerCertificate=True;";
```

##  Autor
* **Nixar Mercado** - *Desarrollo Demostración para clases* - [nixarmercado]([https://github.com](https://github.com/nixarmercado))
