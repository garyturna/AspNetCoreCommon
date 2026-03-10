CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@Id int,
	@Name NVarchar(50)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.[Order]
	SET OrderName = @Name
	WHERE Id = @Id	

END
