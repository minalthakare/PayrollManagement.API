CREATE TABLE Departments
(
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE Employees
(
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName VARCHAR(150) NOT NULL,
    BasicSalary DECIMAL(18,2) NOT NULL,
    DepartmentId INT NOT NULL,

    FOREIGN KEY(DepartmentId)
    REFERENCES Departments(DepartmentId)
);

CREATE TABLE Attendance
(
    AttendanceId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,

    AttendanceMonth INT NOT NULL,
    AttendanceYear INT NOT NULL,

    WorkingDays INT NOT NULL,
    DaysPresent INT NOT NULL,

    FOREIGN KEY(EmployeeId)
    REFERENCES Employees(EmployeeId)
);

CREATE TABLE PayrollRun
(
    PayrollRunId INT IDENTITY(1,1) PRIMARY KEY,

    PayrollMonth INT NOT NULL,
    PayrollYear INT NOT NULL,

    RunDate DATETIME DEFAULT GETDATE(),

    IsFinalized BIT DEFAULT 1
);

CREATE TABLE PayrollDetails
(
    PayrollDetailId INT IDENTITY(1,1) PRIMARY KEY,

    PayrollRunId INT NOT NULL,
    EmployeeId INT NOT NULL,

    BasicSalary DECIMAL(18,2),
    WorkingDays INT,
    DaysPresent INT,

    GrossPay DECIMAL(18,2),
    PFDeduction DECIMAL(18,2),
    ProfessionalTax DECIMAL(18,2),
    NetPay DECIMAL(18,2),

    FOREIGN KEY(PayrollRunId)
    REFERENCES PayrollRun(PayrollRunId),

    FOREIGN KEY(EmployeeId)
    REFERENCES Employees(EmployeeId)
);