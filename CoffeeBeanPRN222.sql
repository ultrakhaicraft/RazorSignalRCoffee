-- Create the CoffeeShop database
CREATE DATABASE CoffeeShop;
GO

-- Use the CoffeeShop database
USE CoffeeShop;
GO

-- Create the Coffee table
CREATE TABLE Coffee (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    unit_price DECIMAL(10, 2) NOT NULL,
    stock_quantity INT NOT NULL DEFAULT 0
);
GO

-- Add some sample data (optional)
INSERT INTO Coffee (name, description, unit_price, stock_quantity)
VALUES 
    ('Espresso', 'Strong Italian coffee brewed by forcing hot water through finely-ground coffee beans', 3.50, 100),
    ('Americano', 'Espresso diluted with hot water', 4.00, 150),
    ('Cappuccino', 'Espresso with steamed milk foam', 4.50, 120),
    ('Latte', 'Espresso with a lot of steamed milk and a small amount of milk foam', 4.75, 130),
    ('Mocha', 'Espresso with chocolate and steamed milk', 5.00, 80);
GO