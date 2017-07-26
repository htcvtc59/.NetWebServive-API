create database BankDB
go
use BankDB
go
create table AccountBank
(
Code nvarchar(100) primary key,
Pass nvarchar(200),
FullName nvarchar(300),
MoneyAmount float
)
go
create table LogBank
(
ID int identity primary key,
DateTranfer date,
ReceiveCode nvarchar(200),
Amount float,
Type varchar(100)
)
select * from LogBank
select * from AccountBank