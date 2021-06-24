using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class CCapataz:CEmpleado
    {
        private uint matriculaP;

        public CCapataz(string DNI, String apellido, String nombre, uint mat) : base(DNI, apellido, nombre)
        {
            this.matricula = mat;
        }


        public uint matricula
        {
            get
            {
                return this.matriculaP;
            }

            set
            {
                this.matriculaP = value;
            }
        }


        public override string darDatos()
        {
            return base.darDatos() + "  Matricula Profesional: " + this.matricula.ToString();
        }

    }
}
