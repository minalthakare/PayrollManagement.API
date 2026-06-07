CREATE PROCEDURE usp_RunPayroll
(
    @Month INT,
    @Year INT
)
AS
BEGIN
    SET NOCOUNT ON;

   
    IF EXISTS
    (
        SELECT 1
        FROM PayrollRun
        WHERE PayrollMonth = @Month
        AND PayrollYear = @Year
    )
    BEGIN
        RAISERROR('Payroll already generated',16,1);
        RETURN;
    END

    DECLARE @PayrollRunId INT;

    
    INSERT INTO PayrollRun
    (
        PayrollMonth,
        PayrollYear,
        RunDate,
        IsFinalized
    )
    VALUES
    (
        @Month,
        @Year,
        GETDATE(),
        1
    );

    SET @PayrollRunId = SCOPE_IDENTITY();

  
    INSERT INTO PayrollDetails
    (
        PayrollRunId,
        EmployeeId,
        BasicSalary,
        WorkingDays,
        DaysPresent,
        GrossPay,
        PFDeduction,
        ProfessionalTax,
        NetPay
    )
    SELECT
        @PayrollRunId,

        E.EmployeeId,

        E.BasicSalary,

        ISNULL(A.WorkingDays,0) AS WorkingDays,

        ISNULL(A.DaysPresent,0) AS DaysPresent,

        
        ROUND
        (
            CASE
                WHEN ISNULL(A.WorkingDays,0) = 0
                THEN 0

                ELSE
                    (E.BasicSalary / A.WorkingDays)
                    * ISNULL(A.DaysPresent,0)
            END,
            2
        ) AS GrossPay,

       
        ROUND
        (
            E.BasicSalary * 0.12,
            2
        ) AS PFDeduction,

       
        200 AS ProfessionalTax,

        
        ROUND
        (
            (
                CASE
                    WHEN ISNULL(A.WorkingDays,0) = 0
                    THEN 0

                    ELSE
                        (E.BasicSalary / A.WorkingDays)
                        * ISNULL(A.DaysPresent,0)
                END
            )
            -
            (E.BasicSalary * 0.12)
            -
            200,
            2
        ) AS NetPay

    FROM Employees E

    LEFT JOIN Attendance A
        ON E.EmployeeId = A.EmployeeId
        AND A.AttendanceMonth = @Month
        AND A.AttendanceYear = @Year;
END
GO