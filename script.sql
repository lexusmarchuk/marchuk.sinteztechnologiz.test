CREATE TYPE [dbo].[OrderProductTable] AS TABLE(
	[ProductId] [int] NULL,
	[Amount] [numeric](18, 2) NULL
)
GO
/****** Object:  Table [dbo].[SintezOrder]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SintezOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerFullName] [varchar](100) NOT NULL,
	[CustomerEmail] [varchar](100) NULL,
	[ShipToAddress] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SintezOrderProduct]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SintezOrderProduct](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SintezProduct]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SintezProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[Price] [numeric](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[SintezOrder] ON 

GO
INSERT [dbo].[SintezOrder] ([Id], [CustomerFullName], [CustomerEmail], [ShipToAddress]) VALUES (1, N'John Snow', N'jsnow@gmail.com', N'nord wall')
GO
INSERT [dbo].[SintezOrder] ([Id], [CustomerFullName], [CustomerEmail], [ShipToAddress]) VALUES (15, N'customer #1', N'test@test.com', N'shipping address')
GO
SET IDENTITY_INSERT [dbo].[SintezOrder] OFF
GO
INSERT [dbo].[SintezOrderProduct] ([OrderId], [ProductId], [Amount]) VALUES (1, 1, CAST(1.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezOrderProduct] ([OrderId], [ProductId], [Amount]) VALUES (1, 2, CAST(8.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezOrderProduct] ([OrderId], [ProductId], [Amount]) VALUES (1, 3, CAST(15.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezOrderProduct] ([OrderId], [ProductId], [Amount]) VALUES (15, 1, CAST(32.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezOrderProduct] ([OrderId], [ProductId], [Amount]) VALUES (15, 2, CAST(32.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[SintezProduct] ON 

GO
INSERT [dbo].[SintezProduct] ([Id], [Name], [Price]) VALUES (1, N'Mykolaiv Pizza 40cm', CAST(99.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezProduct] ([Id], [Name], [Price]) VALUES (2, N'Milk 1L', CAST(22.05 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezProduct] ([Id], [Name], [Price]) VALUES (3, N'Roshen sweets 1Kg', CAST(3.99 AS Numeric(18, 2)))
GO
INSERT [dbo].[SintezProduct] ([Id], [Name], [Price]) VALUES (13, N'random product 775', CAST(13.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[SintezProduct] OFF
GO
ALTER TABLE [dbo].[SintezOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_SintezOrderProduct_SintezOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[SintezOrder] ([Id])
GO
ALTER TABLE [dbo].[SintezOrderProduct] CHECK CONSTRAINT [FK_SintezOrderProduct_SintezOrder]
GO
ALTER TABLE [dbo].[SintezOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_SintezOrderProduct_SintezProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[SintezProduct] ([Id])
GO
ALTER TABLE [dbo].[SintezOrderProduct] CHECK CONSTRAINT [FK_SintezOrderProduct_SintezProduct]
GO
/****** Object:  StoredProcedure [dbo].[addOrder]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addOrder]
	@customerFullName VARCHAR (100),
    @customerEmail    VARCHAR (100),
    @shipToAddress    VARCHAR (300),
	@products as OrderProductTable READONLY
AS
	DECLARE @orderId INT

	INSERT INTO SintezOrder(CustomerFullName, CustomerEmail, ShipToAddress)
	VALUES (@customerFullName, @customerEmail, @shipToAddress)
	
	SELECT @orderId = CAST(SCOPE_IDENTITY() AS INT)

	INSERT INTO SintezOrderProduct(OrderId, ProductId, Amount)
	select @orderId, ProductId, Amount from @products

	RETURN @orderId
GO
/****** Object:  StoredProcedure [dbo].[addProduct]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addProduct]
	@name VARCHAR (300),
	@price NUMERIC (18, 2)
AS	
	INSERT INTO SintezProduct(Name, Price)
	VALUES (@name, @price)

	RETURN SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[getOrder]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getOrder]
	@id int
AS
	SELECT 
		CustomerFullName, 
		CustomerEmail,
		ShipToAddress
	FROM 
		SintezOrder
	WHERE
		Id = @id
	
	SELECT
		ProductId,
		Amount
	FROM
		SintezOrderProduct
	WHERE 
		OrderId = @id
GO
/****** Object:  StoredProcedure [dbo].[getProduct]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getProduct]
	@id int
AS
	SELECT 
		Id, 
		Name, 
		Price
	FROM
		SintezProduct
	WHERE 
		Id = @id
GO
/****** Object:  StoredProcedure [dbo].[getProducts]    Script Date: 1/13/2017 12:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getProducts]

AS
	SELECT 
		Id,
		Name,
		Price
	FROM 
		SintezProduct
GO