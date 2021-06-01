using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFunctions
{
    class Program
    {
        private static Guid _productId = Guid.Parse("1612D8E7-8A18-41AD-8BFA-100E1E2D3854");

        static async Task Main(string[] args)
        {
            await Configure();
            await AddData();
            await Show();
        }

        private static async Task Show()
        {
            await using var db = new DataContext();

            var logs = await db.AuditLogs
                .Where(l => DatabaseFunctions.JsonValue(l.Data, "$.ProductId") == _productId.ToString())
                .ToListAsync();

            foreach (var auditLog in logs)
            {
                Console.WriteLine($"Log: {auditLog.LogType}, Date: {auditLog.LogType}, Data: {auditLog.Data}");
            }
        }

        private static async Task Configure()
        {
            await using var db = new DataContext();
            await db.Database.MigrateAsync();
        }

        private static async Task AddData()
        {
            await using var db = new DataContext();

            if (await db.AuditLogs.AnyAsync())
            {
                return;
            }

            var productLogs = new List<AuditLog>()
            {
                new AuditLog()
                {
                    LogType = nameof(ProductCreated),
                    Data = new ProductCreated(_productId).ToJson()
                },
                new AuditLog()
                {
                    LogType = nameof(ProductUpdated),
                    Data = new ProductUpdated(_productId).ToJson()
                },new AuditLog()
                {
                    LogType = nameof(ProductCreated),
                    Data = new ProductCreated(Guid.NewGuid()).ToJson()
                },
                new AuditLog()
                {
                    LogType = nameof(ProductUpdated),
                    Data = new ProductUpdated(_productId).ToJson()
                }
            };

            await db.AuditLogs.AddRangeAsync(productLogs);
            await db.SaveChangesAsync();
        }
    }
}
