USE master
GO

CREATE DATABASE ZapateroKAV
GO

USE ZapateroKAV
GO

CREATE TABLE Empleado(
	IdEmpleado INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombres VARCHAR(100) NOT NULL,
	Apellidos VARCHAR(100) NOT NULL,
	Estado TINYINT NOT NULL,
	FechaModificacion DATETIME NOT NULL
)

CREATE TABLE Proveedor(
	IdProveedor INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Estado TINYINT NOT NULL,
	FechaModificacion DATETIME NOT NULL
)

CREATE TABLE TipoZapato(
	IdTipoZapato INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	TipoZapato	VARCHAR(100) NOT NULL,
	Estado TINYINT NOT NULL,
	FechaModificacion DATETIME NOT NULL
)


CREATE TABLE CabeceraOrden(
	IdOrden INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	IdEmpleado INT NOT NULL FOREIGN KEY REFERENCES Empleado(IdEmpleado),
	IdProveedor INT NOT NULL FOREIGN KEY REFERENCES Proveedor(IdProveedor),
	FechaIngreso DATETIME NOT NULL,
	TotalPares INT NOT NULL
)

CREATE TABLE DetalleOrden(
	IdOrden INT NOT NULL FOREIGN KEY REFERENCES CabeceraOrden(IdOrden),
	IdOrdenDetalle INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IdTipoZapato INT NOT NULL FOREIGN KEY REFERENCES TipoZapato(IdTipoZapato),
	Cantidad INT NOT NULL
)

--INGRESO DE LOS DATOS PARA CONSUMIRLOS
-- Empleados
INSERT INTO Empleado(Nombres, Apellidos, Estado, FechaModificacion)
VALUES ('Alberto','Torres',1,GETDATE()),('Martha','Perez',1,GETDATE());

--Proveedores
INSERT INTO Proveedor(Nombre, Estado, FechaModificacion)
VALUES ('China Shoes',1,GETDATE()),('American Shoes',1,GETDATE()),('CR Import',1,GETDATE());

--TipoZapatos
INSERT INTO TipoZapato(TipoZapato, Estado, FechaModificacion)
VALUES ('Deportivo',1,GETDATE()),('Casual',1,GETDATE()),('Formal',1,GETDATE());

--QUERYS DE CONSULTAS PARA LA CABECERA Y DETALLE
SELECT a.IdOrden, b.Nombres, c.Nombre, a.FechaIngreso, a.TotalPares 
FROM CabeceraOrden a
LEFT JOIN Empleado b ON a.IdEmpleado = b.IdEmpleado
LEFT JOIN Proveedor c ON a.IdProveedor = c.IdProveedor;

SELECT a.IdOrden, a.IdOrdenDetalle, b.TipoZapato, a.Cantidad
FROM DetalleOrden a
LEFT JOIN TipoZapato b ON a.IdTipoZapato = b.IdTipoZapato;