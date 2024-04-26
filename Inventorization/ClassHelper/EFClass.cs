using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorization.DB;

namespace Inventorization.ClassHelper
{
    public class EFClass
    {
        public static Entities context { get; } = new Entities();
        public static int IDChange;
    }
}
