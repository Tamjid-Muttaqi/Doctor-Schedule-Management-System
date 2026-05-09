# Doctor Schedule Management System

C# Windows Forms desktop application with SQL Server database.

## Features
- Login / logout
- Patient registration
- Multiple user login: SuperAdmin, Admin, User
- Admin doctor CRUD
- Admin schedule CRUD
- Patient appointment booking
- Payment after appointment booking
- Discount coupon and special package support
- Patient review system
- Super Admin can remove doctor based on public reviews
- Payment history view

## Default Login
- SuperAdmin: superadmin / 1234
- Admin: admin / 1234
- User: user / 1234

## Coupons
- STUDENT10 = 10%
- SENIOR20 = 20%
- DIABETES15 = 15%
- EMERGENCY5 = 5%

## Run Steps
1. Open SSMS and run Database.sql.
2. Open DoctorScheduleManagementSystem.sln in Visual Studio.
3. Open Db.cs and change server name in connection string.
4. Run the project.
