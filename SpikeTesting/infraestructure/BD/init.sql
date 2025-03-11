CREATE TABLE Products (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name TEXT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

INSERT INTO Products (Name, Price) VALUES 
('Laptop', 1200),
('Mouse', 25),
('Keyboard', 45);
