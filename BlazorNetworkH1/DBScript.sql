﻿USE Master
GO
CREATE DATABASE BreakfastH1
GO
USE BreakfastH1
GO

CREATE TABLE Food(
id INT IDENTITY(1,1),
Item NVARCHAR(255),
Amount INT,
Price DECIMAL(10,2)
)

INSERT INTO Food VALUES ('Donut', 10, 1.99)

