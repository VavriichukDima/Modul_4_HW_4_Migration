using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Modul_4_HW_2__createBD_
{
    public class LazyLoading
    {
        private readonly ApplicationsContext _context;

        public LazyLoading(ApplicationsContext context)
        {
            _context = context;
        }

        public async Task LoadThreeTablesAsync()
        {
            var loadThreeTables2 = await _context.Titles
                .Select(x => new
                {
                    Title = x.Name,
                    Employee = x.Employees.Select(v => v.FirstName),
                    Office = x.Employees.Select(c => c.OfficeId)
                })
                .ToListAsync();

            Console.WriteLine("----LoadThreeTables----");
            foreach (var temp in loadThreeTables2)
            {
                Console.WriteLine($"Title: {temp.Title} -- Employee: {temp.Employee} -- Office: {temp.Office}");
            }
        }

        public async Task DateDiffAsync()
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

        public async Task ChangeEntityAsync()
        {
            var changeEntity = await _context.Employees.FirstOrDefaultAsync(z => z.EmployeeId == 2);
            changeEntity.FirstName = "Vavriichuk";
            var changeEntity2 = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == 3);
            changeEntity2.DateOfBirth = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public async Task AddEntityAsync()
        {
            var addEntityEmployeeProject = await _context.EmployeeProjects.AddAsync(new Entities.EmployeeProject
            {
                Rate = 10000,
                StartedDate = new DateTime(1876, 12, 30),
                ProjectId = 1,
                Employee = new Entities.Employee
                {
                    FirstName = "AAA",
                    LastName = "BBB",
                    HiredDate = new DateTime(1998, 10, 10),
                    DateOfBirth = new DateTime(1987, 12, 13),
                    TitleId = 2,
                    OfficeId = 3,
                }
            });

            _context.SaveChanges();
        }

        public async Task DeleteEntityAsync()
        {
            var deleteEntity = await _context.Employees.FirstOrDefaultAsync();
            _context.Remove(deleteEntity);

            _context.SaveChanges();
        }

        public async Task GroupRoleEmployeeAsync()
        {
            var groupRoleEmployee = await _context.Employees
                .Where(w => !w.Title.Name.Contains("A"))
                .GroupBy(z => z.Title.Name)
                .Select(s => s.Key)
                .ToListAsync();

            Console.WriteLine("----GroupRoleEmployee----");
            foreach (var temp in groupRoleEmployee)
            {
                Console.WriteLine(temp);
            }
        }
    }
}