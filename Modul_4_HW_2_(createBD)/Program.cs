using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Modul_4_HW_2__createBD_
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).LoadThreeTables();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).DateDiff();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).ChangeEntity();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).AddEntity();
            }

            // await using (var context = new SampleContextFactory().CreateDbContext(args))
            // {
            //    await new LazyLoading(context).DeleteEntity();
            // }
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).GroupRoleEmployee();
            }
        }
    }
}