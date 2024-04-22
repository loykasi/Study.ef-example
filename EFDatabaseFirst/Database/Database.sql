CREATE DATABASE CompanyDatabaseFirstDb
GO
USE CompanyDatabaseFirstDb
GO

CREATE TABLE Company
(
	CompanyId INT PRIMARY KEY,
	CompanyName NVARCHAR(255)
)

CREATE TABLE Department
(
	DepartmentId INT PRIMARY KEY,
	DepartmentName NVARCHAR(255),
	CompanyId INT FOREIGN KEY REFERENCES Company(CompanyId)
)

CREATE TABLE Employee
(
	EmployeeId INT PRIMARY KEY,
	EmployeeName NVARCHAR(255),
	Gender INT,
	AGE INT,
	DepartmentId INT FOREIGN KEY REFERENCES Department(DepartmentID)
)

GO
INSERT INTO Company
VALUES
(1, 'TStudio');

INSERT INTO Department
VALUES
(1, 'Marketing', 1),
(2, 'Human Resources', 1),
(3, 'Finance', 1);

INSERT INTO Employee
VALUES
(1, 'John David', 1, 35, 1),
(2, 'Luke Kovad', 1, 28, 2),
(3, 'Nad Alov', 1, 38, 3),
(4, 'Kovad Bob', 1, 38, 1),
(5, 'Olov Colav', 1, 41, 1),
(6, 'Tob Dom', 1, 29, 1);

select * from Company
select * from Department
select * from Employee