using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Data
{
    public class MySqlConfiguracion
    {
        public MySqlConfiguracion(string conectionString)
        {
            ConnectionString = conectionString;
        }

        public string ConnectionString { get; set; }
    }
}
