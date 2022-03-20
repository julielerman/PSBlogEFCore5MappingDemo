using Microsoft.EntityFrameworkCore.Migrations;

namespace MappingDemo.Migrations
{
    public partial class addudfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             CREATE FUNCTION [dbo].[TotalSpentbyCustomer]
             (	@CustomerId int	)
             RETURNS int
             AS
             BEGIN
             	-- Declare the return variable here
             	DECLARE @TotalSpent int
             	SELECT @TotalSpent = sum(LineItem.Quantity * Product.UnitPrice)
             	FROM LineItem
             	INNER JOIN Orders ON LineItem.OrderId = Orders.OrderId
             	INNER JOIN Product ON LineItem.ProductId = Product.ProductId
             	WHERE Orders.customerid = @CustomerId
             
             	RETURN @TotalSpent
             
             END");
            migrationBuilder.Sql(@"
             CREATE FUNCTION [dbo].[CustomerNameAndTotalSpent] ()
             RETURNS TABLE
             AS
             RETURN (
             		SELECT customers.name,
             			dbo.TotalSpentbyCustomer(customers.Customerid) AS TotalSpent
             		FROM Customers
             		)"
             );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION[dbo].[CustomerNameAndTotalSpent]");
            migrationBuilder.Sql("DROP FUNCTION[dbo].[TotalSpentbyCustomer]");
        }
    }
}
