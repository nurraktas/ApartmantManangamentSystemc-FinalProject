# 🏢 Apartment Management System | Final Project

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8%2B-purple)
![Platform](https://img.shields.io/badge/Platform-Windows-blue)
![UI Framework](https://img.shields.io/badge/UI-WPF%20%2F%20XAML-green)


> **A comprehensive desktop solution designed to digitize and streamline property management operations using modern .NET technologies.**

## 📖 Overview

The **Apartment Management System** is a robust desktop application built with **C#** and **WPF (Windows Presentation Foundation)**. It serves as a centralized hub for building managers to handle tenant data, financial transactions, and apartment occupancy status efficiently.

Originally conceptualized with Windows Forms, the project has been re-engineered with a **modern XAML-based UI** to ensure a better user experience (UX) and scalability. It also features an experimental **AI Module** (`ApartmentAI`) intended for future predictive analytics in property management.

---

## 🚀 Key Features

### 👤 Tenant Administration Module (`Tenant.xaml`)
Managing residents is the core of this system. This module allows for:
* **Onboarding:** Seamless registration of new tenants with detailed profile management.
* **Database Management:** View, edit, and archive tenant contact information and lease agreements.
* **Occupancy Tracking:** Visual indicators for occupied vs. vacant units.

### 💰 Financial & Transaction Hub (`RentPayment.xaml`)
A dedicated financial module to ensure transparency in accounting:
* **Payment Processing:** Log rent and dues payments securely.
* **History Logs:** Access historical payment data for specific apartments or tenants.
* **Status Tracking:** Identify overdue payments and generate basic financial summaries.

### 🧠 ApartmentAI (Experimental)
An integrated Artificial Intelligence infrastructure designed to:
* Analyze historical payment data.
* Provide future insights on expense estimation (Beta).

---

## 🛠️ Tech Stack & Architecture

This project follows a modular architecture using the **MVVM (Model-View-ViewModel)** pattern principles where applicable, ensuring separation between logic and design.

| Category | Technology Used |
| :--- | :--- |
| **Language** | C# (C-Sharp) |
| **User Interface** | WPF (Windows Presentation Foundation) / XAML |
| **Framework** | .NET Framework |
| **Database** | SQL Server / ADO.NET |
| **Package Manager**| NuGet (`packages.config`) |
| **Version Control**| Git & GitHub |



## ⚙️ Installation & Setup

Follow these steps to set up the environment and run the application locally.

### Prerequisites
1.  **Visual Studio 2019 or 2022** (Enterprise/Professional/Community).
2.  **.NET Desktop Development** workload installed via Visual Studio Installer.
3.  **SQL Server** (LocalDB or Express) for database connectivity.

### Step-by-Step Guide

1.  **Clone the Repository**
    ```bash
    git clone [https://github.com/nurraktas/ApartmantManangamentSystemc-FinalProject.git](https://github.com/nurraktas/ApartmantManangamentSystemc-FinalProject.git)
    ```

2.  **Open the Solution**
    Navigate to the folder and open `ApartmentManagementSystem.sln` in Visual Studio.

3.  **Restore Dependencies**
    The project relies on external packages managed by `packages.config`.
    * Right-click on the **Solution** in the Solution Explorer.
    * Select **"Restore NuGet Packages"**.

4.  **Configure Database**
    * Open `App.config`.
    * Locate the `<connectionStrings>` tag.
    * Update the `Data Source` and `Initial Catalog` to match your local SQL Server instance.

5.  **Build & Run**
    * Press **F5** or click the **Start** button to launch the application.

---

## 📂 Project Structure

```text
ApartmentManagementSystem/
├── 📂 ApartmentAI/           # AI & Prediction Logic
├── 📂 ApartmentManagementSystem/
│   ├── 📄 App.xaml           # Application Entry & Resources
│   ├── 📄 MainWindow.xaml    # Main Dashboard UI
│   ├── 📄 Tenant.xaml        # Tenant Operations UI
│   ├── 📄 RentPayment.xaml   # Financial Operations UI
│   ├── 📄 packages.config    # Dependencies
│   └── 📄 App.config         # Database Configurations
└── 📄 .gitignore             # Git Configuration
