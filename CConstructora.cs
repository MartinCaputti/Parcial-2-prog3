using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class CConstructora
    {
        private ArrayList personal;

        public CConstructora()
        {
            this.personal = new ArrayList(0);
        }

        public CEmpleado buscar(String DNI)
        {
            foreach (CEmpleado aux in this.personal)
            {
                if (aux.getDni() == DNI)
                {
                    return aux;
                }
            }
            return null;
        }


        public bool nuevoObrero(string dni , string apellido , string nombre ,int special)
        {
            CObrero nObrero;
            if (buscar(dni) == null )
            {
                nObrero = new CObrero(dni, apellido, nombre, special);
                this.personal.Add(nObrero);
             
                return true;
            }
            return false;
        }

        public bool nuevoCapataz(string dni, string apellido, string nombre, uint matri)
        {
            CCapataz nCapataz;
            if (buscar(dni) == null)
            {
                nCapataz = new CCapataz(dni, apellido, nombre, matri);
                this.personal.Add(nCapataz);

                return true;
            }
            return false;
        }


        public bool eliminarEmpleado(string dni)
        {
            if (buscar(dni) is CObrero)
            {
                CObrero nObrero = (CObrero)buscar(dni);
                this.personal.Remove(nObrero);
                Console.WriteLine("obrero borrado");
                return true;
            }

            if (buscar(dni) is CCapataz)
            {
                CCapataz nCapataz = (CCapataz)buscar(dni);
                this.personal.Remove(nCapataz);
                Console.WriteLine("capataz borrado");
                return true;
            }

            return false; 
        }

        
        public void listarTodos(CObras obras)
        {
           
            this.personal.Sort();
            string concat;
            this.personal.TrimToSize();
            if (this.personal.Count == 0)
            {
                Console.WriteLine( "No hay empleados para mostrar");
            }

            foreach (CEmpleado aux in this.personal)
            {
                concat = aux.darDatos();
                if(aux is CObrero)
                {
                    concat += " [Obrero]";

                    if (obras.empleadoActivo((CObrero) aux) == true)
                    {
                        concat += " ACTIVO";
                    }else
                    {
                        concat += " No pertenece a ninguna obra";
                    }

                }

                if(aux is CCapataz)
                {
                    concat += " [Capataz]";
                    if (obras.empleadoActivo((CCapataz)aux) == true)
                    {
                        concat += " ACTIVO";
                    }else
                    {
                        concat += " No pertenece a ninguna obra";
                    }
                }
                Console.WriteLine(concat);
            }
        }
        

        //No se puede eliminar a un empleado de la constructora mientras sea parte de una obra 
        public bool despedirEmpleado(CObras obras , string dni)
        {

            if (buscar(dni) is CObrero)
            {
                CObrero nObrero = (CObrero)buscar(dni);
                if (obras.empleadoActivo(nObrero) == true)
                {
                    Console.WriteLine("El obrero pertenece a una obra activa");
                    return false;
                }
                else
                {
                    this.personal.Remove(nObrero);
                    Console.WriteLine("obrero borrado");
                    return true;
                }                            
            }

            if (buscar(dni) is CCapataz)
            {
                CCapataz nCapataz = (CCapataz)buscar(dni);
                if (obras.empleadoActivo(nCapataz) == true)
                {
                    Console.WriteLine("El Capataz es encargado de una obra activa");
                    return false;
                }
                else
                {
                    this.personal.Remove(nCapataz);
                    Console.WriteLine("Capataz borrado");
                    return true;
                }
            }

            return false;
        }
                
    }
}
