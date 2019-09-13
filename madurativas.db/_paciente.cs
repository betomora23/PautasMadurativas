using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madurativas.db
{
    public partial class Paciente
    {
        public string FullName => $"{nombre} {apellidos}";
    }
}
