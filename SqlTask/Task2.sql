-- Создание таблицы "Продукты" с атрибутами: 
-- ID_Product - ID элемента (автоинкремент, первичный ключ)
-- Product_Name - название продукта
CREATE TABLE Products
(
	ID_Product int NOT NULL IDENTITY (1,1),
	Product_Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (ID_Product)
)
GO

-- Создание таблицы "Категории" с атрибутами: 
-- ID_Category - ID элемента (автоинкремент, первичный ключ)
-- Category_Name - название категории
CREATE TABLE Categories
(
	ID_Category int NOT NULL IDENTITY (1,1),
	Category_Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY (ID_Category)
)
GO

-- Создание таблицы "Продукты и категории" для корректной реализации связи "многие ко многим". 
-- Атрибуты: 
-- ID_Record - ID элемента (автоинкремент, первичный ключ)
-- ID_Product - ID продукта
-- ID_Category - ID соответствующей ему категории
CREATE TABLE ProductsAndCategories
(
	ID_Record int NOT NULL IDENTITY (1,1),
	ID_Product int NOT NULL,
	ID_Category int NOT NULL,
	CONSTRAINT PK_ProductsAndCategories PRIMARY KEY (ID_Record)
)
GO

-- Установка внешних ключей на таблицу "Продукты и категории".
-- Поле ID_Product является внешним ключом к таблице Products
ALTER TABLE ProductsAndCategories
ADD
FOREIGN KEY (ID_Product) REFERENCES Products (ID_Product)
GO

-- Поле ID_Category является внешним ключом к таблице Categories
ALTER TABLE ProductsAndCategories
ADD
FOREIGN KEY (ID_Category) REFERENCES Categories (ID_Category)
GO

-- Заполнение таблиц данными
INSERT INTO Products (Product_Name) 
VALUES ('Набор карандашей'),
		('Лента декоративная'),
		('Полимерная глина'),
		('Набор для вышивки'),
		('Пальчиковые краски')
GO

INSERT INTO Categories (Category_Name) 
VALUES ('Товары для художников'),
		('Детское творчество'),
		('Лепка')
GO

INSERT INTO ProductsAndCategories (ID_Product, ID_Category) 
VALUES (1, 1),
		(1, 2),
		(3, 3),
		(4, 2),
		(5, 2)
GO

-- SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
-- Если у продукта нет категорий, то его имя все равно выводится.
SELECT Products.Product_Name, Categories.Category_Name
	FROM Products
	LEFT OUTER JOIN ProductsAndCategories ON ProductsAndCategories.ID_Product = Products.ID_Product 
	LEFT OUTER JOIN Categories ON ProductsAndCategories.ID_Category = Categories.ID_Category  