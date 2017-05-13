using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using WebMVC_MSSQL.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC_MSSQL
{
    public class SampleData
    {

        internal static async Task InitializeCache(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //var cache = serviceScope.ServiceProvider.GetService<IDistributedCache>();

                //if (cache != null)
                //{
                //    await cache.SetAsync("Key1", Encoding.UTF8.GetBytes("Key1Value"));
                //    await cache.SetAsync("Key2", Encoding.UTF8.GetBytes("Key2Value"));
                //}

                //var conn = serviceScope.ServiceProvider.GetService<ConnectionMultiplexer>();
                //if (conn != null)
                //{
                //    var db = conn.GetDatabase();
                //    db.StringSet("ConnectionMultiplexorKey1", "Key1Value via ConnectionMultiplexor");
                //    db.StringSet("ConnectionMultiplexorKey2", "Key2Value via ConnectionMultiplexor");
                //}
            }
        }

        internal static void InitializeMyContexts(IServiceProvider serviceProvider)
        {

            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ReleaseContext>();
                db.Database.EnsureCreated();
            }
            InitializeContext(serviceProvider);
        }

        private static void InitializeContext(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ReleaseContext>();
                if (DataExists<Release>(db))
                    return;
                var _rel = new Release() { Id = 1, ApplicationName = "Release Notes Web Application" };
                AddData<Release>(db, _rel);
                AddData<ReleaseNote>(db, new ReleaseNote() { Id = 1, Data = "Initial Release", Release = _rel});
                db.SaveChanges();
            }
        }

        private static bool DataExists<TData>(DbContext db) where TData : class
        {
            var existingData = db.Set<TData>().ToList();
            if (existingData.Count > 0)
                return true;
            return false;
        }

        private static void AddData<TData>(DbContext db, object item) where TData : class
        {
            db.Entry(item).State = EntityState.Added;
        }
    }
}
