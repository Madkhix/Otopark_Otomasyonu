using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Otopark_Otomasyonu
{
    class BaglanClass
    {
        public static string sqlconnection = ConfigurationManager.ConnectionStrings["Otopark_Otomasyonu"].ConnectionString;
    }
}
