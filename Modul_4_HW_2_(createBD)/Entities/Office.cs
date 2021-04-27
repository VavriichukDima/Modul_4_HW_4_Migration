using System.Collections.Generic;

namespace Modul_4_HW_2__createBD_.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
