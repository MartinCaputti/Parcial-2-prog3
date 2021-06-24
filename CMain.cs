using System;

namespace Parcial2
{
    class CMain
    {
        static void Main(string[] args)
        {
            
            CMenu menu;
            menu = new CMenu();
            string opcion ;
            do
            {
                menu.mostarOpciones();
                menu.setOpcion(opcion = Console.ReadLine());
               
            } while (opcion != "0");

           
        }
    }
}
