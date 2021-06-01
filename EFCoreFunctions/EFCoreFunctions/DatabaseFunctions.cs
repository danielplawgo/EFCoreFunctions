using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EFCoreFunctions
{
    public static class DatabaseFunctions
    {
        public static string JsonValue(string source, string path) => throw new NotSupportedException();

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(DatabaseFunctions).GetMethod(nameof(JsonValue)))
                .HasTranslation(args => SqlFunctionExpression.Create("JSON_VALUE", args, typeof(string), null));
        }
    }
}