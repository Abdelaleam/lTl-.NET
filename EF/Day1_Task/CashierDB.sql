USE [master]
GO
CREATE DATABASE CashierDB;
GO
USE CashierDB;
GO
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);
CREATE TABLE Sales (
    SaleId INT PRIMARY KEY IDENTITY(1,1),
    SaleDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL
);

CREATE TABLE SaleDetails (
    SaleDetailId INT PRIMARY KEY IDENTITY(1,1),
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

INSERT INTO Products (ProductName, Price, Stock) VALUES
(N'Kebda Sandwich', 25.00, 100),
(N'Sogo2 Sandwich', 30.00, 80),
(N'Chicken Shawarma', 35.00, 60),
(N'French Fries', 15.00, 200),
(N'Spiro Spathis', 12.00, 120),
(N'Water Bottle', 7.00, 100);
