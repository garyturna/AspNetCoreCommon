CREATE PROCEDURE [dbo].[spFood_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	SELECT [Id], [Title], [Description], [Price] 
	FROM dbo.Food

END
