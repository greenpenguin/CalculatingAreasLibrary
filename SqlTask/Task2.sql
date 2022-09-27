-- �������� ������� "��������" � ����������: 
-- ID_Product - ID �������� (�������������, ��������� ����)
-- Product_Name - �������� ��������
CREATE TABLE Products
(
	ID_Product int NOT NULL IDENTITY (1,1),
	Product_Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (ID_Product)
)
GO

-- �������� ������� "���������" � ����������: 
-- ID_Category - ID �������� (�������������, ��������� ����)
-- Category_Name - �������� ���������
CREATE TABLE Categories
(
	ID_Category int NOT NULL IDENTITY (1,1),
	Category_Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY (ID_Category)
)
GO

-- �������� ������� "�������� � ���������" ��� ���������� ���������� ����� "������ �� ������". 
-- ��������: 
-- ID_Record - ID �������� (�������������, ��������� ����)
-- ID_Product - ID ��������
-- ID_Category - ID ��������������� ��� ���������
CREATE TABLE ProductsAndCategories
(
	ID_Record int NOT NULL IDENTITY (1,1),
	ID_Product int NOT NULL,
	ID_Category int NOT NULL,
	CONSTRAINT PK_ProductsAndCategories PRIMARY KEY (ID_Record)
)
GO

-- ��������� ������� ������ �� ������� "�������� � ���������".
-- ���� ID_Product �������� ������� ������ � ������� Products
ALTER TABLE ProductsAndCategories
ADD
FOREIGN KEY (ID_Product) REFERENCES Products (ID_Product)
GO

-- ���� ID_Category �������� ������� ������ � ������� Categories
ALTER TABLE ProductsAndCategories
ADD
FOREIGN KEY (ID_Category) REFERENCES Categories (ID_Category)
GO

-- ���������� ������ �������
INSERT INTO Products (Product_Name) 
VALUES ('����� ����������'),
		('����� ������������'),
		('���������� �����'),
		('����� ��� �������'),
		('����������� ������')
GO

INSERT INTO Categories (Category_Name) 
VALUES ('������ ��� ����������'),
		('������� ����������'),
		('�����')
GO

INSERT INTO ProductsAndCategories (ID_Product, ID_Category) 
VALUES (1, 1),
		(1, 2),
		(3, 3),
		(4, 2),
		(5, 2)
GO

-- SQL ������ ��� ������ ���� ��� ���� �������� � ��� ���������. 
-- ���� � �������� ��� ���������, �� ��� ��� ��� ����� ���������.
SELECT Products.Product_Name, Categories.Category_Name
	FROM Products
	LEFT OUTER JOIN ProductsAndCategories ON ProductsAndCategories.ID_Product = Products.ID_Product 
	LEFT OUTER JOIN Categories ON ProductsAndCategories.ID_Category = Categories.ID_Category  