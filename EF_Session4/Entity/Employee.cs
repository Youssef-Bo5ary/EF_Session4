using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Session4.Entity
{
    internal class Employee : IComparable<Employee>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }

        [ForeignKey("Department")]
        public int DeptId {  get; set; }
        
        public Department Department { get; set; }

        public int CompareTo(Employee? other)
        => this.Salary.CompareTo(other?.Salary);
           
        
    }
}
