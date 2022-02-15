CREATE DATABASE dbHoyNoCircula
GO

USE dbHoyNoCircula

create table tblUsuario(
idUsuario int primary key,
nombre varchar (100),
apellido varchar(100),
cedula varchar(10),
direccionIp varchar(50),
puerto varchar(50),
)

create table tblDia(
idDia int primary key,
dia varchar(10)
)

create table tblHorarioNoCircula(
idHorarioNoCircula int primary key,
idDia int,
digito1 int,
digito2 int,
digito3 int,
digito4 int,
CONSTRAINT fkHorDia FOREIGN KEY (idDia) REFERENCES tblDia(idDia)
)

create table tblPlaca(
idPlaca int primary key,
numPlaca varchar(50)
--idUsuario int,
--CONSTRAINT fkPlacUsu FOREIGN KEY (idUsuario) REFERENCES tblUsuario(idUsuario)
)

create table tblMotivo(
idMotivo int primary key,
nombreMotivo varchar(50)
)

create table tblSalvoconducto(
idSalvoconducto int,
idPlaca int,
idMotivo int,
estadoSalvoconducto varchar(50),
fechaEmision date,
fechaFin date,
CONSTRAINT fkSalvPlac FOREIGN KEY (idPlaca) REFERENCES tblPlaca(idPlaca),
CONSTRAINT fkSalvMoti FOREIGN KEY (idMotivo) REFERENCES tblMotivo(idMotivo)
)

create table tblPedido(
idPedido int primary key,
tipodepedido varchar(50)
)

create table tblPedidoUsuario(
idPedidoUsuario int primary key,
idUsuario int,
idPedido int,
idPlaca int,
CONSTRAINT fkPedUsuUsu FOREIGN KEY (idUsuario) REFERENCES tblUsuario(idUsuario),
CONSTRAINT fkPedUsuPed FOREIGN KEY (idPedido) REFERENCES tblPedido(idPedido),
CONSTRAINT fkPedUsuPlac FOREIGN KEY (idPlaca) REFERENCES tblPlaca(idPlaca)
)

create table tblPlacaHorarioNoCircula(
idPlacaHorario int primary key,
idPlaca int,
idHorarioNoCircula int,
CONSTRAINT fkPlacaHorPac FOREIGN KEY (idPlaca) REFERENCES tblPlaca(idPlaca),
CONSTRAINT fkPlacaHorHor FOREIGN KEY (idHorarioNoCircula) REFERENCES tblHorarioNoCircula(idHorarioNoCircula)
)

---------------- VALORES BASE DE DATOS -------------------------------------

INSERT INTO tblDia VALUES(1,'Lunes'),
(2,'Martes'),
(3,'Miercoles'),
(4,'Jueves'),
(5,'Viernes')

INSERT INTO tblHorarioNoCircula VALUES(1,1,0,1,2,3),
(2,2,2,3,4,5),
(3,3,4,5,6,7),
(4,4,6,7,8,9),
(5,5,8,9,0,1)

INSERT INTO tblMotivo VALUES(1,'Trabajo'),
(2,'Estudio'),
(3,'Citas Medicas'),
(4,'Deporte'),
(5,'Fiesta'),
(6,'Discapacidad')

INSERT INTO tblPedido VALUES(1,'Consulta Horario'),
(2,'Emision Salvoconducto')

INSERT INTO tblUsuario VALUES(1,'Austin','Schultz','40012823','10.10.5.2','19568'),
(2,'Brett','Blackburn','21600950','10.10.2.5','11000'),
(3,'Selma','Evans','43385641','10.45.23.2','12526'),
(4,'Emerald','Mclaughlin','32774925','10.5.1.5','10254'),
(5,'Desiree','Irwin','12168871','10.5.6.1','65254'),
(6,'Deborah','Gibson','17514288','10.4.5.6','555568')

INSERT INTO tblPlaca VALUES(1,'PBS-4040'),
(2,'ABC-5489'),
(3,'DEF-1234'),
(4,'FGH-9856'),
(5,'PLR-4897')

INSERT INTO tblSalvoconducto VALUES(1,1,1,'Si','2021-07-15',null),
(2,2,3,'Si','2021-07-16',null),
(3,3,6,'Si','2021-06-14',null),
(4,4,2,'No',null,null)


INSERT INTO tblPlacaHorarioNoCircula VALUES(1,1,1),
(2,1,5),
(3,2,4),
(4,2,5),
(5,3,2),
(6,3,3),
(7,4,3),
(8,4,4),
(9,5,3),
(10,5,4)


INSERT INTO tblPedidoUsuario VALUES(1,1,1,1)



--MUESTRA DIA QUE NO CIRCULA
go
CREATE VIEW horario as 
SELECT numPlaca, tblDia.dia
from tblPlacaHorarioNoCircula
INNER JOIN tblPlaca ON tblPlaca.idPlaca = tblPlacaHorarioNoCircula.idPlaca
INNER JOIN tblHorarioNoCircula ON tblHorarioNoCircula.idHorarioNoCircula = tblPlacaHorarioNoCircula.idHorarioNoCircula
INNER JOIN tblDia ON tblHorarioNoCircula.idDia = tblDia.idDia

-- MMUESTRA LOS PEDIDOS REALIZADOS POR UN USUARIO
go
CREATE VIEW pedidos as 
select tblUsuario.nombre, tblUsuario.apellido, tblPlaca.numPlaca,tblPedido.tipodepedido
from tblPedidoUsuario
INNER JOIN tblUsuario ON tblUsuario.idUsuario = tblPedidoUsuario.idUsuario
INNER JOIN tblPedido ON tblPedido.idPedido = tblPedidoUsuario.idPedido
INNER JOIN tblPlaca ON tblPlaca.idPlaca = tblPedidoUsuario.idPlaca

--MUESTRA LOS SALVOCONDCTOS

go
CREATE VIEW salvoconductos as 
select tblPlaca.numPlaca, tblMotivo.nombreMotivo, tblSalvoconducto.estadoSalvoconducto, fechaEmision, fechaFin
from tblSalvoconducto
INNER JOIN tblMotivo ON tblMotivo.idMotivo = tblSalvoconducto.idMotivo
INNER JOIN tblPlaca ON tblPlaca.idPlaca = tblSalvoconducto.idPlaca


--INGRESA O REGISTRA

go
CREATE PROC ingresar
@nombre varchar (100),
@apellido varchar(100),
@cedula varchar(10),
@direccionIp varchar(50),
@puerto varchar(50)
AS
BEGIN
IF ((select cedula from tblUsuario where cedula = @cedula) = @cedula)
	BEGIN
	select *
	from tblUsuario
	where cedula = @cedula
	END
ELSE
	BEGIN
	INSERT INTO tblUsuario VALUES ((SELECT TOP 1 idUsuario+1 from tblUsuario ORDER BY idUsuario desc),
	@nombre,@apellido,@cedula,@direccionIp,@puerto)
	select *
	from tblUsuario
	where cedula = @cedula
	END
END


/*
EXEC ingresar
	@nombre = 'Edan',
	@apellido = 'Berry',
	@cedula = '1514845',
	@direccionIp = '10.4.1.2',
	@puerto = '45857'
*/


--HACER UN PEDIDO DE HORARIO

go
CREATE PROC mostrarHorario
@cedula varchar(100),
@numPlaca varchar(50)
AS
BEGIN
IF ((select numPlaca from tblPlaca where numPlaca = @numPlaca) = @numPlaca)
	BEGIN
	select *
	from horario
	where numPlaca = @numPlaca
	--Se registra el pedido
	INSERT INTO tblPedidoUsuario VALUES (
	(SELECT TOP 1 idPedidoUsuario+1 from tblPedidoUsuario ORDER BY idPedidoUsuario desc),
	(select idUsuario from tblUsuario where cedula = @cedula),
	(1),
	(select idPlaca from tblPlaca where numPlaca = @numPlaca))
	END
ELSE
	BEGIN
	--inserta la placa
	INSERT INTO tblPlaca VALUES (
	(SELECT TOP 1 idPlaca+1 from tblPlaca ORDER BY idPlaca desc),
	@numPlaca)
	--inserta al hoy no circula
	declare @hor1 int
	declare @hor2 int
	if((SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=0 or 
	(SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=1)
		begin 
		set @hor1=1
		set @hor2=5
		END
	if((SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=2 or
	(SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=3)
		begin 
		set @hor1=1
		set @hor2=2
		END
	if((SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=4 or 
	(SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=5)
		begin 
		set @hor1=2
		set @hor2=3
		END
	if((SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=6 or
	(SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=7)
		begin 
		set @hor1=3
		set @hor2=4
		END
	if((SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=8 or
	(SELECT CAST(right(numPlaca, 1) AS int) from tblPlaca where numPlaca = @numPlaca)=9)
		begin 
		set @hor1=4
		set @hor2=5
		END	
	INSERT INTO tblPlacaHorarioNoCircula VALUES (
	(SELECT TOP 1 idPlacaHorario+1 from tblPlacaHorarioNoCircula ORDER BY idPlacaHorario desc),
	(select idPlaca from tblPlaca where numPlaca = @numPlaca),
	(@hor1))
	INSERT INTO tblPlacaHorarioNoCircula VALUES (
	(SELECT TOP 1 idPlacaHorario+1 from tblPlacaHorarioNoCircula ORDER BY idPlacaHorario desc),
	(select idPlaca from tblPlaca where numPlaca = @numPlaca),
	(@hor2))
	select *
	from horario
	where numPlaca = @numPlaca
	--Registrar el pedido
	INSERT INTO tblPedidoUsuario VALUES (
	(SELECT TOP 1 idPedidoUsuario+1 from tblPedidoUsuario ORDER BY idPedidoUsuario desc),
	(select idUsuario from tblUsuario where cedula = @cedula),
	(1),
	(select idPlaca from tblPlaca where numPlaca = @numPlaca))
	END
END


/*
EXEC mostrarHorario
	@cedula = '43385641',
	@numPlaca = 'GHG-4587'
*/


--HACER UN PEDIDO DE SALVOCONDUCTO

go
CREATE PROC hacerSalvoconducto
@cedula varchar(100),
@numPlaca varchar(50),
@idMotivo int
AS
BEGIN
declare @idPlaca int
set @idPlaca = (select idPlaca from tblPlaca where numPlaca = @numPlaca)
IF((select idPlaca from tblSalvoconducto where idPlaca = @idPlaca)=@idPlaca and 
(select estadoSalvoconducto from tblSalvoconducto where idPlaca = @idPlaca)='Si')
	BEGIN
	PRINT 'YA HAY UN SALVOCONDUCTO'
	END
ELSE
	BEGIN 
	IF (@idMotivo = 4 or @idMotivo = 5)
		BEGIN
		--Actualiza tabla salvoconducto
		INSERT INTO tblSalvoconducto VALUES (
		(SELECT TOP 1 idSalvoconducto+1 from tblSalvoconducto ORDER BY idSalvoconducto desc),
		(select idPlaca from tblPlaca where numPlaca = @numPlaca),
		@idMotivo,'No',null,NULL)
		select * from salvoconductos where numPlaca = @numPlaca 
		END
	ELSE
		BEGIN
		--Actualiza tabla salvoconducto
		INSERT INTO tblSalvoconducto VALUES (
		(SELECT TOP 1 idSalvoconducto+1 from tblSalvoconducto ORDER BY idSalvoconducto desc),
		(select idPlaca from tblPlaca where numPlaca = @numPlaca),
		@idMotivo,'Si',GETDATE(),DATEADD(DAY,8,GETDATE()))
		--Registrar el pedido
		INSERT INTO tblPedidoUsuario VALUES (
		(SELECT TOP 1 idPedidoUsuario+1 from tblPedidoUsuario ORDER BY idPedidoUsuario desc),
		(select idUsuario from tblUsuario where cedula = @cedula),
		(2),
		(select idPlaca from tblPlaca where numPlaca = @numPlaca))
		select * from salvoconductos where numPlaca = @numPlaca 
		END
	END
END

/*
EXEC hacerSalvoconducto
	@cedula = '43385641',
	@numPlaca = 'GHG-4587',
	@idMotivo = 1
*/



/*

use master 
go 
drop database dbHoyNoCircula

*/
