using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class CMenu
    {
        private CConstructora constructora1;
        private CObras obras;

        public  CMenu()
        {
            constructora1 = new CConstructora();
            obras = new CObras();

            /* Metodos para ya tener algunos datos precargados 
            constructora1.nuevoObrero("1", "Caputti", "martin", 2);
            constructora1.nuevoCapataz("2", "Morgan", "Dexter", 10);
            constructora1.nuevoObrero("15", "Walter", "White", 3);
            constructora1.nuevoObrero("198", "Bruce", "Wayne", 2);
            constructora1.nuevoCapataz("5", "Eddie", "Guerrero", 21);
            constructora1.nuevoCapataz("10", "MAX", "POWER", 33);
            obras.agregarObra("1", "WERNICKE 2343 ,BUENOS AIRES ,ARGENTINA");
            obras.agregarObra("55", "Rue de Rivoli, 75001 Paris, Francia");
            obras.asignarCapataz("1",(CCapataz) constructora1.buscar("2") );
            obras.asignarObrero("1", (CObrero) constructora1.buscar("1"));
            obras.asignarObrero("1", (CObrero)constructora1.buscar("198"));
            obras.agregarObra("961", "London HA9 0WS, Reino Unido");
            */
        }

        public void mostarOpciones()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*                     Menu                    *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[1] Registrar Obrero en la constructora.");
            Console.WriteLine("\n[2] Registrar Capataz en la constructora.");
            Console.WriteLine("\n[3] Agregar Obra.");
            Console.WriteLine("\n[4] Agregar obrero a la obra.");
            Console.WriteLine("\n[5] Asignar Capataz a la obra.");
            Console.WriteLine("\n[6] Listar todas las obras actuales.");
            Console.WriteLine("\n[7] Listar obreros en una obra en particular");
            Console.WriteLine("\n[8] Remover obrero de una obra.");
            Console.WriteLine("\n[9] Despedir empleado de la constructora");
            Console.WriteLine("\n[10] Listar todos los empleados.");
            Console.WriteLine("\n[0] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            
        }
           
        public void setOpcion(string opcion)
        {
            switch (opcion)
            {
                //registrar obrero
                case "1":
                    {
                        string dni, apellido, nombre;
                        int special;
                        Console.WriteLine("Ingrese los datos del nuevo obrero");
                        Console.WriteLine("DNI:");
                        dni = Console.ReadLine();
                        Console.WriteLine("Apellido:");
                        apellido = Console.ReadLine();
                        Console.WriteLine("Nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("ingrese numero de oficio:[1] albañil/ [2] pintor/ [3]plomero/ [4]herrero/ [5]electricista");
                        special = int.Parse(Console.ReadLine());

                        if (constructora1.nuevoObrero(dni, apellido, nombre, special) == true)
                        {
                            Console.WriteLine("Se agrego el nuevo obrero a la  constructora");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar o el obrero ya existia en la constructora");
                        }
                        PParaContinuar();
                        break;
                    }
                //registrar capataz
                case "2":
                    {
                        string dni, apellido, nombre;
                        uint mat;
                        Console.WriteLine("Ingrese los datos del nuevo Capataz");
                        Console.WriteLine("DNI:");
                        dni = Console.ReadLine();
                        Console.WriteLine("Apellido:");
                        apellido = Console.ReadLine();
                        Console.WriteLine("Nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Numero de matricula profesional:");
                        mat = uint.Parse(Console.ReadLine());
                        if (constructora1.nuevoCapataz(dni, apellido, nombre, mat) == true) {
                            Console.WriteLine("Se agrego el nuevo capataz a la constructora");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar o el capataz ya existia en la constructora");
                        }
                        PParaContinuar();
                        break;
                    }
                //registrar obras
                case "3":
                    {
                        string codigo, direccion;
                        Console.WriteLine("Ingrese los datos de la nueva obra");
                        Console.WriteLine("codigo alfanumerico:");
                        codigo = Console.ReadLine();
                        Console.WriteLine("direccion completa:");
                        direccion = Console.ReadLine();

                        if (obras.agregarObra(codigo, direccion) == true)
                        {
                            Console.WriteLine("Obra registrada con exito ");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar o la obra ya estaba registrada ");
                        }

                        PParaContinuar();
                        break;
                    }
                //asignar obrero a obra
                case "4":
                    {
                        string codigo, dni;
                        CObrero nuevoObrero;
                        Console.WriteLine("Ingrese el codigo de la obra");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Ingrese el DNI del obrero");
                        dni = Console.ReadLine();

                        if (constructora1.buscar(dni) is CObrero)
                        {
                            nuevoObrero = (CObrero)constructora1.buscar(dni);
                            if (obras.asignarObrero(codigo, nuevoObrero) == true)
                            {
                                Console.WriteLine("obrero asignado a la obra codigo: " + codigo);
                            }
                            else
                            {
                                Console.WriteLine("Codigo de obra erroneo");
                            }

                        }
                        else
                        {
                            Console.WriteLine("No hay obreros con ese dni ");
                        }
                        PParaContinuar();
                        break;
                    }
                //asignar capataz a la obra
                case "5":
                    {
                        string codigo, dni;
                        CCapataz nuevoCapataz;
                        Console.WriteLine("Ingrese el codigo de la obra");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Ingrese el DNI del capataz");
                        dni = Console.ReadLine();

                        if (constructora1.buscar(dni) is CCapataz)
                        {
                            nuevoCapataz = (CCapataz)constructora1.buscar(dni);
                            if (obras.asignarCapataz(codigo, nuevoCapataz) == true)
                            {
                                Console.WriteLine("Capataz asignado a la obra codigo: " + codigo);
                            }
                            else
                            {
                                Console.WriteLine("Codigo de obra erroneo ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay Capataz con ese dni ");
                        }
                        PParaContinuar();
                        break;
                    }
                //Listar todas las obras activas
                case "6":
                    {
                        obras.todasLasObras();
                        PParaContinuar();
                        break;
                    }
                //Listar datos de obreros en una obra
                case "7":
                    {
                        string codigo;
                        Console.WriteLine("ingrese el codigo de la obra a mostar");
                        codigo = Console.ReadLine();

                        obras.mostrarObrerosObra(codigo);
                        PParaContinuar();
                        break;
                    }
                //Remover Obrero de una obra 
                case "8":
                    {
                        string codigo, dni;
                        Console.WriteLine("ingrese el codigo de la obra");
                        codigo = Console.ReadLine();
                        Console.WriteLine("ingrese el dni del obrero a remover de la obra");
                        dni = Console.ReadLine();
                        obras.eliminarObreroDeObra(codigo, dni);

                        PParaContinuar();
                        break;
                    }
                //Despedir de la constructora
                case "9":
                    {
                        string dni;
                        Console.WriteLine("ingrese el dni del obrero a remover de la obra");
                        dni = Console.ReadLine();
                        constructora1.despedirEmpleado(obras, dni);

                        PParaContinuar();
                        break;
                    }
                //Listar todos los empleados de la constructora , con su cargo  ,datos y si estan desocupados
                case "10":
                    {

                        constructora1.listarTodos(obras);
                        PParaContinuar();
                        break;
                    }


                //Salir del Menu 
                case "0":
                    {
                        Console.WriteLine("adios!");
                        break;
                    }
                //Si ingresan cualquier otro valor 
                default:
                    {
                        Console.WriteLine("Opcion invalida");
                        Console.ReadLine();
                        break;
                    }
            }

        }

        public static void PParaContinuar()
        {
            Console.WriteLine("enter para continuar");
            Console.ReadLine();

        }

    }
}
