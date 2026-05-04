# Doctor Schedule Management System

A desktop-based **Doctor Schedule Management System** developed using **C# Windows Forms** with database integration. The application helps manage doctors, schedules, patient appointments, user roles, and public reviews in a structured healthcare environment.

## Project Information

| Item | Details |
|---|---|
| Course | CSC2210: Object Oriented Programming 2 |
| University | American International University-Bangladesh (AIUB) |
| Department | Department of Computer Science |
| Project Name | Doctor Schedule Management System |
| Technology | C# Windows Forms, SQL Database |
| Submitted By | Tamjid Muttaqi |
| Student ID | 24-57591-2 |
| Supervisor | Dr. Md. Iftekharul Mobin |

## Introduction

In real-life healthcare scenarios, patients often face difficulty finding available doctors and booking appointments without schedule conflicts. The **Doctor Schedule Management System** solves this problem by providing a desktop-based platform where patients can view doctors, check available schedules, and book appointments easily.

The system supports multiple user roles, including **Super Admin**, **Admin**, and **Patient/User**. Each role has different access levels and functionalities. The project includes CRUD operations, role-based access control, appointment management, database integration, and validation features.

## Objectives

- Manage doctor information efficiently.
- Maintain doctor schedules with available days and time slots.
- Allow patients to register, log in, view doctors, and book appointments.
- Prevent duplicate appointments for the same doctor schedule.
- Allow patients to give reviews and ratings.
- Allow admins and super admins to monitor system activity.
- Provide a user-friendly Windows Forms graphical interface.

## User Roles and Features

### Super Admin

- Log in to the system.
- View all doctors and users.
- Monitor public reviews.
- Remove doctors based on negative reviews.
- Manage system-level operations.

### Admin

- Log in to the system.
- Add new doctor information.
- Update existing doctor information.
- Delete doctor records.
- Manage doctor schedules.
- View all appointments.

### Patient / User

- Register and log in.
- View available doctors.
- Check available schedules.
- Book appointments.
- Give reviews and ratings.

## System Features

- Role-based login system.
- Doctor management.
- Schedule management.
- Appointment booking.
- Review and rating system.
- Database integration.
- CRUD operations.
- Data validation.
- Appointment conflict prevention.
- User-friendly graphical interface.

## ER Diagram

The ER diagram represents the relationships among users, doctors, schedules, appointments, and reviews.

![ER Diagram](images/er-diagram.png)

## Normalization

### Relationship: Doctor Has Schedule

**UNF**

```text
DoctorName, Specialization, Day, Time, Status
```

**1NF**

```text
DoctorName, Specialization, Day, Time, Status
```

**2NF / 3NF**

```text
Doctors(DoctorId, DoctorName, Specialization)
DoctorSchedule(ScheduleId, DoctorId, Day, Time, Status)
```

### Relationship: User Books Appointment

**UNF**

```text
UserName, DoctorName, Date, Time, Status
```

**1NF**

```text
UserName, DoctorName, Date, Time, Status
```

**2NF / 3NF**

```text
Users(UserId, Username, Password, Role)
Appointments(AppointmentId, UserId, DoctorId, Date, Time, Status)
```

### Relationship: User Gives Review

**UNF**

```text
UserName, DoctorName, Rating, Comment
```

**1NF**

```text
UserName, DoctorName, Rating, Comment
```

**2NF / 3NF**

```text
Users(UserId, Username)
Reviews(ReviewId, UserId, DoctorId, Rating, Comment)
```

## Final Tables

After normalization, the final database contains the following tables:

1. Users
2. Doctors
3. DoctorSchedule
4. Appointments
5. Reviews

## Database Schema

The database schema shows the final table structure and the relationships among tables.

![Database Schema](images/database-schema.png)

## Database Query

```sql
CREATE DATABASE DoctorScheduleDB;
USE DoctorScheduleDB;

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50),
    Password VARCHAR(50),
    Role VARCHAR(20)
);

CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY(1,1),
    DoctorName VARCHAR(100),
    Specialization VARCHAR(100),
    ChamberLocation VARCHAR(100)
);

CREATE TABLE DoctorSchedule (
    ScheduleId INT PRIMARY KEY IDENTITY(1,1),
    DoctorId INT,
    DayName VARCHAR(20),
    StartTime VARCHAR(20),
    EndTime VARCHAR(20),
    Status VARCHAR(20),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    DoctorId INT,
    ScheduleId INT,
    AppointmentDate DATE,
    Status VARCHAR(20),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (ScheduleId) REFERENCES DoctorSchedule(ScheduleId)
);

CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    DoctorId INT,
    Rating INT,
    Comment VARCHAR(255),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
```

## Validation and Verification

The system includes validation to ensure that required input fields are not left empty and appointment data is handled properly. The appointment booking process verifies doctor availability and helps prevent duplicate bookings for the same time slot.

## Conclusion

The **Doctor Schedule Management System** provides an organized desktop-based solution for managing doctors, schedules, appointments, and reviews. By using C# Windows Forms and database integration, the system reduces manual work, improves appointment management, and supports different user roles through a structured interface.

