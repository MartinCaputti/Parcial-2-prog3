using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class CObras
    {
        private ArrayList listadoObras;

        public CObras()
        {
            this.listadoObras = new ArrayList(0);
        }

        public CObra buscarObra(string codigo)
        {
            foreach (CObra aux in this.listadoObras)
            {
                if (aux.getCodigo() == codigo)
                {
                    return aux;
                }
            }
            return null;
        }

        public bool agregarObra(string codigo,string direccion)
        {
            CObra nuevaObra;
            if (buscarObra(codigo) == null)
            {
                nuevaObra = new CObra(codigo, direccion);
                this.listadoObras.Add(nuevaObra);

                return true;
            }
            return false;
        }

        public bool eliminarObra(string codigo )
        {
            CObra nuevaObra = buscarObra(codigo);
            if ( nuevaObra != null)
            {
                this.listadoObras.Remove(nuevaObra);
                Console.WriteLine("obra borrada");
                return true;
            }

            return false;
        }

        public bool asignarCapataz(string codigo ,CCapataz nuevoCapataz)
        {
            CObra obra = buscarObra(codigo);
            //Si la obra existe 
            if (obra != null )
            {
                //le asigno uno
                obra.setCapataz(nuevoCapataz);
                return true;
            }
            return false;
        }

        public bool asignarObrero(string codigo,CObrero nuevoObrero)
        {
            //Busco la obra
            CObra obra = buscarObra(codigo);
            //si existe
            if(obra!= null)
            {
                //ingreso el nuevo obrero 
                obra.nuevoObrero(nuevoObrero);
                return true;
            }
            return false;
        }

        public void todasLasObras()
        {
            listadoObras.TrimToSize();
            if (listadoObras.Count == 0)
            {
                Console.WriteLine("no hay obras en ejecucion");
            }
            else 
            { 
                foreach (CObra aux in listadoObras)
                {
                    Console.WriteLine("\nObra:" + aux.darDatos());
                }
            }
        }

        public void mostrarObrerosObra(string codigo)
        {
            CObra obra = buscarObra(codigo);
            if ( obra != null)
            {
                Console.WriteLine("Obra: " + codigo );
                Console.WriteLine(obra.mostrarObreros());
            }
            else
            {
                Console.WriteLine("\nNo se encontro la obra");
            }
        }

        public bool eliminarObreroDeObra(string codigo ,string dni)
        {
            //Busco la obra
            CObra obra = buscarObra(codigo);
            //si existe
            if (obra != null)
            {
                //busco al obrero para eliminarlo
                if (obra.eliminarObrero(dni) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool empleadoActivo(CObrero obreroABuscar)
        {
            //recorro todas las obras en todas las obras
            foreach(CObra aux in this.listadoObras)
            {
                //En cada una busco al obrero 
                if(aux.buscar(obreroABuscar.getDni())  == obreroABuscar)
                {
                    //Si lo encuentro significa que esta activo
                    return true;

                }

            }

            //Si no lo encontre en ninguna obra , no esta activo
            return false;

        }
        //Uso la sobrecarga de metodos para poder utilizarlo segun sea el caso
        public bool empleadoActivo(CCapataz capatazABuscar)
        {
            //recorro todas las obras en todas las obras
            foreach (CObra aux in this.listadoObras)
            {
                //En cada una busco al capataz de la obra
                if(aux.getCapataz() == capatazABuscar)
                {
                    //Si lo encontre esta activo
                    return true;
                }

            }

            //Si no lo encontre en ninguna obra , no esta activo
            return false;

        }

    }
}
