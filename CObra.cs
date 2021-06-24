using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class CObra
    {
        private string codigo;
        private string direccion;
        private CCapataz capataz;
        private ArrayList obreros;

        public CObra(string codigo ,string direccion)
        {
            this.codigo = codigo;
            this.direccion = direccion;
            this.capataz = null;
            obreros = new ArrayList(0);

        }

        public string getCodigo()
        {
            return this.codigo;
        }

        //asignar capataz
        public void setCapataz(CCapataz capataz)
        {
            this.capataz = capataz;
        }

        public CCapataz getCapataz()
        {
            return this.capataz;
        }

        public CObrero buscar(String DNI)
        {
            foreach (CObrero aux in this.obreros)
            {
                if (aux.getDni() == DNI)
                {
                    return aux;
                }
            }

            return null;

        }

        //Asignar obrero a obra en ejecucion 
        public bool nuevoObrero(CObrero nuevoObrero)
        {
             
            //Veo si el obrero no es parte de la obra
            if (buscar(nuevoObrero.getDni()) == null)
            {
                //si no lo es lo agrego
                this.obreros.Add(nuevoObrero);
                return true;
            }
            return false;
        }

        //Remover obrero de la obra en ejecucion
        public bool eliminarObrero(string dni)
        {

            if (buscar(dni) != null)
            {
                CObrero nObrero = (CObrero)buscar(dni);
                this.obreros.Remove(nObrero);
                Console.WriteLine("obrero borrado de la obra");
                return true;
            }
            Console.WriteLine("No se encontro al obrero");
            return false;
        }

        public string darDatos()
        {
            string concat;
            concat = "\nCodigo: " + this.codigo + "\nDireccion: " + this.direccion;

            if(this.capataz != null)
            {
                concat +="\nCapataz a cargo : " + getCapataz().darDatos();
            }
            else
            {
                concat += "\nAun NO hay un capataz asignado";
            }

            return concat ;
        }

        public string mostrarObreros()
        {
            string concat = ""; 
            foreach(CObrero aux in obreros)
            {
                concat += "\n" + aux.darDatos();
            }

            if (concat == "")
            {
                return "no hay obreros asignados a esta obra";
            }

            return concat;
        }

    }
}
