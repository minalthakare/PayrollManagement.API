# Payroll Management System

## Project Overview

This project is a Payroll Management System developed as part of the ASP.NET Core Full Stack Developer Technical Assessment.

The application allows HR users to:

 View employees
 Generate monthly payroll
 View payroll details for a selected month and year
 View and print employee payslips
 Download payroll data in CSV format

The solution follows a layered architecture using ASP.NET Core Web API, ADO.NET, SQL Server, HTML, JavaScript, and Stored Procedures.

---

# Technology Stack

* ASP.NET Core 8 Web API
* SQL Server
* ADO.NET
* HTML
* JavaScript
* xUnit

---

# Project Structure

PayrollManagement.API

* Controllers
* Services
* Repositories
* Models
* Dtos
* Database Scripts
* Frontend (HTML + JavaScript)
* Unit Tests

Architecture used:

UI Layer (HTML / JavaScript)

API Controllers

Service Layer

Repository Layer

Stored Procedure

SQL Server Database


# Setup Instructions

Follow the steps below to run the application locally.

## Step 1: Open the Project

Open the solution in Visual Studio 2022.

## Step 2: Create Database

Open SQL Server Management Studio (SSMS).

Execute:

CREATE DATABASE PayrollDB;

Then select:

USE PayrollDB;

## Step 3: Execute Database Scripts

Run the scripts in the following order:

1. Tables.sql
2. SeedData.sql
3. StoredProcedure.sql
4. Indexes.sql

## Step 4: Configure Connection String

Open appsettings.json and update the connection string.

Example:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PayrollDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}

## Step 5: Build the Solution

Build → Rebuild Solution

Ensure the solution builds successfully without errors.

## Step 6: Run the Application

Press F5.

Swagger will open automatically.

## Step 7: Open Frontend

Navigate to:

https://localhost:{port}/index.html

to access the Payroll Management UI.

# API Endpoints

## Get Employees
GET /api/employees  :-Returns all employees.

## Run Payroll
POST /api/payroll/run :- Generates payroll for the selected month and year.

Request:
json
{
  "month": 6,
  "year": 2026
}
 201 Created
 409 Conflict (if payroll already exists)

## Get Payroll By Month And Year

GET /api/payroll/{month}/{year} :-Returns payroll records for the selected period.

Example:
GET /api/payroll/6/2026

Supports pagination.

Example:
GET /api/payroll/6/2026?page=1&pageSize=5

## Get Employee Payslip

GET /api/payroll/{runId}/slip/{employeeId} :-Returns payroll details for a single employee.

Example:
GET /api/payroll/1/slip/1

# Frontend Usage

Open:
https://localhost:{port}/index.html

Features:
 Select Month
 Select Year
 Run Payroll
 View Payroll Results
 Download Payroll CSV
 Print Payroll

Payslip Page:
https://localhost:{port}/Payslip.html

Features:
 View Payslip
 Print Payslip

---

# Payroll Calculation Rules

Gross Pay
(Basic Salary ÷ Working Days) × Days Present

PF Deduction
12% of Basic Salary

Professional Tax
₹200 per month

Net Pay
Gross Pay − PF Deduction − Professional Tax

# Business Rules Implemented

 Duplicate payroll generation is prevented.
 Payroll runs are immutable after generation.
 Missing attendance records are handled safely.
 Divide-by-zero scenarios are prevented.
 HTTP 409 Conflict is returned for duplicate payroll runs.
 Payroll data supports pagination.
 Printable payslips are available.

# Unit Testing
xUnit has been used for testing payroll calculation logic.

Test cases included:

 Normal attendance scenario
 Full attendance scenario
 Zero attendance scenario
 Low attendance scenario

# Assumptions Made

The following assumptions were made during implementation:

1. Professional Tax is fixed at ₹200 per month for all employees.

2. PF deduction is fixed at 12% of Basic Salary.

3. Payroll is generated once per month and year combination.

4. Once payroll is generated, it is considered finalized and cannot be modified.

5. Attendance records are maintained monthly.

6. Employees without attendance records should still be included in payroll processing with zero attendance values.

---

# What I Would Improve With More Time

If additional time were available, I would enhance the solution by adding:

 Authentication and Authorization
 Role-based access for HR users
 Export to Excel and PDF
 Dashboard and reporting screens
 Audit logging
 Email payslip functionality
 Better UI styling using Bootstrap
 Integration tests and controller tests

# Known Limitations

Due to the scope and timeline of the assessment:

 Authentication was not implemented.
 Payroll approval workflow was not implemented.
 Advanced reporting features were not implemented.
 PDF generation was not implemented.

These features would be added in a production-ready version.
