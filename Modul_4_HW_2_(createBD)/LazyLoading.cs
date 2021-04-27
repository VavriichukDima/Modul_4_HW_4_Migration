using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Modul_4_HW_2__createBD_
{
    public class LazyLoading
    {
        private readonly ApplicationsContext _context;

        public LazyLoading(ApplicationsContext context)
        {
            _context = context;
        }

        public async Task LoadThreeTables()
        {
            var loadThreeTables = await _context.EmployeeProjects.Select(z => new
            {
                EmployeeProject = z.EmployeeProjectId,
                Employee = z.Employee.FirstName,
                Project = z.Project.Name
            })
                .ToListAsync();

            Console.WriteLine("----LoadThreeTables----");
            foreach (var temp in loadThreeTables)
            {
                Console.WriteLine($"Project: {temp.Project} -- ProjectID: {temp.EmployeeProject} -- Employee: {temp.Employee}");
            }
        }

        public async Task DateDiff()
        {
            var diff = await _context.Employees
                     .Select(z => new
                     {
                         z.FirstName,
                         z.HiredDate,
                         Exp = DateTime.Now.Year - z.HiredDate.Year
                     })
                     .ToListAsync();

            Console.WriteLine("----DateDiff----");
            foreach (var i in diff)
            {
                Console.WriteLine(i);
            }
        }

        public async Task ChangeEntity()
        {
            var changeEntity = await _context.Employees.FirstOrDefaultAsync(z => z.EmployeeId == 1);
            changeEntity.FirstName = "Vavriichuk";
            var changeEntity2 = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == 2);
            changeEntity2.DateOfBirth = DateTime.UtcNow;
            _context.SaveChanges();
        }

        public async Task AddEntity()
        {
            var addEntityEmployeeProject = await _context.EmployeeProjects.AddAsync(new Entities.EmployeeProject
            {
                EmployeeProjectId = 10,
                Rate = 100,
                StartedDate = new DateTime(1876, 12, 30),
                ProjectId = 1,
                EmployeeId = 10,
                Employee = new Entities.Employee
                {
                    FirstName = "AAA",
                    LastName = "BBB",
                    HiredDate = new DateTime(1998, 10, 10),
                    DateOfBirth = new DateTime(1987, 12, 13),
                    TitleId = 1,
                    OfficeId = 1,
                }
            });
            _context.SaveChanges();
        }

        // public async Task DeleteEntity()
        // {
        //    var deleteEntity = await _context.Employees.Remove(Entities.Employee employeeId == 3);

        // _context.SaveChanges();
        // }
        public async Task GroupRoleEmployee()
        {
            var groupRoleEmployee = await _context.Titles
                .Where(z => z.Name
                .Contains('a'))
                .GroupBy(z => z.Employees)
                .Select(z => z.Key)
                .ToListAsync();

            Console.WriteLine("----GroupRoleEmployee----");
            foreach (var temp in groupRoleEmployee)
            {
                Console.WriteLine(temp);
            }
        }
    }
}