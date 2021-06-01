using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFCoreFunctions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonSerializer.Serialize(value);
        }
    }
}
