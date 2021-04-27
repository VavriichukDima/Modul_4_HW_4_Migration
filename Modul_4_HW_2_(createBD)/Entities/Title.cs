using System.Collections.Generic;

namespace Modul_4_HW_2__createBD_.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
