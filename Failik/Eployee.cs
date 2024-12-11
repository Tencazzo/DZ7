using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Failik
{
    class Employee
    {
        public string Name { get; }
        public Employee Manager { get; }
        public List<Employee> Subordinates { get; }

        public Employee(string name, Employee manager)
        {
            Name = name;
            Manager = manager;
            Subordinates = new List<Employee>();
            if (manager != null)
            {
                manager.Subordinates.Add(this);
            }
        }

        public bool CanTakeTask(Task task)
        {
            Employee recipient = task.Recipient;
            while (recipient != null)
            {
                if (recipient == this)
                {
                    return true;
                }
                recipient = recipient.Manager;
            }
            return false;
        }
    }
}
