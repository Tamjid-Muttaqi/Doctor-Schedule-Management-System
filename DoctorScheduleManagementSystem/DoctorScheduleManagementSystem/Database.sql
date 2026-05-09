USE master;
GO
IF DB_ID('DoctorScheduleDB') IS NOT NULL
BEGIN
    ALTER DATABASE DoctorScheduleDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DoctorScheduleDB;
END
GO
CREATE DATABASE DoctorScheduleDB;
GO
USE DoctorScheduleDB;
GO
CREATE TABLE Users (UserId INT PRIMARY KEY IDENTITY(1,1), FullName VARCHAR(100) NOT NULL, Username VARCHAR(50) NOT NULL UNIQUE, Password VARCHAR(50) NOT NULL, Email VARCHAR(100), Phone VARCHAR(20), Role VARCHAR(20) NOT NULL);
GO
CREATE TABLE Doctors (DoctorId INT PRIMARY KEY IDENTITY(1,1), DoctorName VARCHAR(100) NOT NULL, Specialization VARCHAR(100), ChamberLocation VARCHAR(100));
GO
CREATE TABLE DoctorSchedule (ScheduleId INT PRIMARY KEY IDENTITY(1,1), DoctorId INT NOT NULL, DayName VARCHAR(20) NOT NULL, StartTime VARCHAR(20) NOT NULL, EndTime VARCHAR(20) NOT NULL, Status VARCHAR(20) NOT NULL DEFAULT 'Available', FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId));
GO
CREATE TABLE Appointments (AppointmentId INT PRIMARY KEY IDENTITY(1,1), UserId INT NOT NULL, DoctorId INT NOT NULL, ScheduleId INT NOT NULL, AppointmentDate DATE NOT NULL, Status VARCHAR(30) NOT NULL, FOREIGN KEY (UserId) REFERENCES Users(UserId), FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId), FOREIGN KEY (ScheduleId) REFERENCES DoctorSchedule(ScheduleId));
GO
CREATE TABLE Reviews (ReviewId INT PRIMARY KEY IDENTITY(1,1), UserId INT NOT NULL, DoctorId INT NOT NULL, Rating INT NOT NULL, Comment VARCHAR(255), FOREIGN KEY (UserId) REFERENCES Users(UserId), FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId));
GO
CREATE TABLE Coupons (CouponId INT PRIMARY KEY IDENTITY(1,1), CouponCode VARCHAR(50) NOT NULL, Description VARCHAR(150), DiscountPercent INT NOT NULL, CaseType VARCHAR(100));
GO
CREATE TABLE Payments (PaymentId INT PRIMARY KEY IDENTITY(1,1), AppointmentId INT NOT NULL, Amount DECIMAL(10,2) NOT NULL, CouponCode VARCHAR(50), CaseType VARCHAR(100), DiscountAmount DECIMAL(10,2), FinalAmount DECIMAL(10,2), PaymentMethod VARCHAR(50), PaymentStatus VARCHAR(20), PaymentDate DATETIME DEFAULT GETDATE(), FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId));
GO
INSERT INTO Users(FullName,Username,Password,Email,Phone,Role) VALUES ('Super Admin','superadmin','1234','superadmin@gmail.com','01700000000','SuperAdmin'),('Admin','admin','1234','admin@gmail.com','01711111111','Admin'),('Patient User','user','1234','user@gmail.com','01722222222','User');
GO
INSERT INTO Doctors(DoctorName,Specialization,ChamberLocation) VALUES ('Dr. Rahman','Cardiologist','Room 101'),('Dr. Karim','Neurologist','Room 202'),('Dr. Ayesha','Dermatologist','Room 303');
GO
INSERT INTO DoctorSchedule(DoctorId,DayName,StartTime,EndTime,Status) VALUES (1,'Monday','09:00 AM','10:00 AM','Available'),(1,'Monday','10:00 AM','11:00 AM','Available'),(1,'Wednesday','02:00 PM','03:00 PM','Available'),(2,'Tuesday','11:00 AM','12:00 PM','Available'),(2,'Thursday','03:00 PM','04:00 PM','Available'),(3,'Saturday','05:00 PM','06:00 PM','Available');
GO
INSERT INTO Coupons(CouponCode,Description,DiscountPercent,CaseType) VALUES ('STUDENT10','Student patient discount package',10,'Student'),('SENIOR20','Senior citizen special package',20,'Senior Citizen'),('DIABETES15','Diabetes patient special package',15,'Diabetes'),('EMERGENCY5','Emergency case support discount',5,'Emergency');
GO
SELECT * FROM Users; SELECT * FROM Doctors; SELECT * FROM DoctorSchedule; SELECT * FROM Coupons;
GO
