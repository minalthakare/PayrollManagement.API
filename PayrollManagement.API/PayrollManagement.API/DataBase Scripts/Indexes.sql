CREATE UNIQUE INDEX IX_PayrollRun_MonthYear
ON PayrollRun
(
    PayrollMonth,
    PayrollYear
);

CREATE INDEX IX_Attendance_MonthYearEmployee
ON Attendance
(
    AttendanceMonth,
    AttendanceYear,
    EmployeeId
);

CREATE INDEX IX_PayrollDetails_RunEmployee
ON PayrollDetails
(
    PayrollRunId,
    EmployeeId
);