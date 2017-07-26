create database EmployeeDB
go
use EmployeeDB
go
create table Employee
(
StudentID int identity primary key,
FirstName nvarchar(200),
LastName nvarchar(200),
PhoneNumber varchar(200),
Email varchar(200)
)
