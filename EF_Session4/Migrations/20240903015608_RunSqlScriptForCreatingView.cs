using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Session4.Migrations
{
    /// <inheritdoc />
    public partial class RunSqlScriptForCreatingView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create View EmployeeDepView
                                   with Encryption 
                                   As
                                   select E.ID [EmployeeID] , E.Name [EmployeeName] ,D.DepId [DepartmentID] ,D.Name [DepartmentName]
                                   from Departments D , Employees E
                                   where D.DepId = E.DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view EmployeeDepView");
        }
    }
}
