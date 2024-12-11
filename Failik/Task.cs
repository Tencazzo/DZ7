using H_W_21._10._23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Failik
{
    class Task
    {
        public string Name { get; }
        public Employee Recipient { get; }
        public TaskType Type { get; }

        public Task(string name, Employee recipient, TaskType type)
        {
            Name = name;
            Recipient = recipient;
            Type = type;
        }
    }

}
