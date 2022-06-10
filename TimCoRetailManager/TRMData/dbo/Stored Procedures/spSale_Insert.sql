﻿CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id int output,
	@CashierId nvarchar(128),
	@SaleDate datetime2,
	@SubTotal money,
	@Tax money,
	@Total money
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Sale]
		([CashierId]
		,[SaleDate]
		,[Subtotal]
		,[Tax]
		,[Total])
	VALUES
		(@CashierId
		,@SaleDate
		,@Subtotal
		,@Tax
		,@Total)
		
	SELECT @id = SCOPE_IDENTITY();
END