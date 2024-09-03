using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Session4.Entity
{
    internal class Department
    {
        public int DepId { get; set; }// Pk 
        public string? Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        //Navigational property => Many
    }
}
