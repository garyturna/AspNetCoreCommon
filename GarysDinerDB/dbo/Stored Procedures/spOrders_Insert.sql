CREATE PROCEDURE [dbo].[spOrders_Insert]
	@OrderName NVarchar(50), 
	@OrderDate DateTime2(7),
	@FoodId INT,
	@Quantity INT, 
	@Total MONEY,
	@Id int OUTPUT
AS
BEGIN

	SET NOCOUNT ON

	INSERT INTO dbo.[Order] ([OrderName], [OrderDate], [FoodId], [Quantity], [Total])
	VALUES (@OrderName, @OrderDate, @FoodId, @Quantity, @Total)	

	SET @Id = SCOPE_IDENTITY()
END


