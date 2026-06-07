INSERT INTO Departments
VALUES
('HR'),
('IT');

INSERT INTO Employees
(
EmployeeName,
BasicSalary,
DepartmentId
)
VALUES
('Ravi Sharma',30000,1),
('Amit Kumar',35000,1),
('Neha Patil',40000,2),
('Priya Singh',45000,2),
('Vikas Gupta',50000,2);

INSERT INTO Attendance
(
EmployeeId,
AttendanceMonth,
AttendanceYear,
WorkingDays,
DaysPresent
)
VALUES
(1,6,2026,26,24),
(2,6,2026,26,25),
(3,6,2026,26,22),
(4,6,2026,26,26),
(5,6,2026,26,23);