CREATE DATABASE PruebaProductos;
GO
USE PruebaProductos;
GO

CREATE TABLE Producto(
Id INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(30),
Descripcion VARCHAR(50),
Marca VARCHAR(35),
Precio DECIMAL(5,2),
Stock INT
);

--Imgreso de valores a la tabla
INSERT INTO Producto VALUES
('Gaseosa','3 Litros','Coca Cola',87,15),
('Leche','Leche en Caja 100 ml','Letty Leche',25,100),
('Jugo','Caja Naranja','Mi Marca',16.5,50)
GO

SELECT * FROM Producto;

CREATE PROC MostrarProductos
AS
SELECT * FROM Producto
GO

EXEC MostrarProductos;

CREATE PROC InsertarProductos
--Los parametros van antes de AS
@Nombre varchar(30),
@Descripcion varchar(50),
@Marca varchar(35),
@Precio decimal(5,2),
@Stock int
AS
INSERT INTO Producto Values(@Nombre,@Descripcion,@Marca,@Precio,@Stock);
GO

EXEC InsertarProductos 'Caramelos','Sabor menta','Capri',15.2,10

CREATE PROC EditarProductos
@Nombre VARCHAR(30),
@Descripcion VARCHAR(50),
@Marca VARCHAR(35),
@Precio DECIMAL(5,2),
@Stock int,
@Id int
AS
UPDATE Producto SET Nombre=@Nombre, Descripcion=@Descripcion,Marca=@Marca,Precio=@Precio,Stock=@Stock
WHERE Id=@Id;
GO

EXEC EditarProductos 'Bebida','Bebida Gaseosa','Pepsi',35,10, 1;

CREATE PROC EliminarProductos
@IdPro INT
AS
DELETE FROM Producto Where Id = @IdPro
GO

EXEC EliminarProductos 5