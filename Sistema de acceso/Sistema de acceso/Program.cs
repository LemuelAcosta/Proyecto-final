using System;
using System.Collections;
using System.Dynamic;
using System.Linq.Expressions;

namespace Sistema_de_acceso
{
    public class Empleados
    {
        public string nombre { get; set; }
        public DateTime Fecha_creac { get; set; }
        public bool actividad { get; set; }
        public string rol { get; set; }
    }
    class Program
    {//Funcion para autenticar los datos.
        public static void autenticacion()
        {
            Console.WriteLine("Sistema de acceso");
            //Aqui estan los usuarios ya predeterminados, las llaves son el usuario y el valor de este Hashtable es la contrasena.
            Hashtable aunthentic = new Hashtable();
            //entrada de datos
            aunthentic.Add(40234533211, 10000);
            aunthentic.Add(40258324500, 12340);
            aunthentic.Add(12300115204, 20000);
            
            int password;
            long user = 0;
            bool paso;
            int contador = 0;
            do
            {

                contador++;
                paso = false;
                Console.WriteLine();
                if (contador > 3)
                {
                    Console.WriteLine("Ya ha intentado ingresar {0} veces, desea registrarse? S/N", contador - 1);
                    string SN = Console.ReadLine();
                    if (SN == "S" || SN == "s")
                    {
                        registrarse();
                        paso = true;
                    }
                }
                if (paso == false)
                {
                    Console.WriteLine("Ingrese su Usuario/Numero de cedula");
                    user = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Ingrese su clave");
                    password = Convert.ToInt32(Console.ReadLine());

                    if (aunthentic.ContainsKey(user) && aunthentic[user].Equals(password))
                    {
                        paso = true;
                    }
                    else if (!aunthentic.ContainsKey(user) || !aunthentic.ContainsValue(password) && contador < 3)
                    {
                        Console.WriteLine("Usuario o Contraseña incorrecto");

                    }
                }
            } while (paso == false);
            Console.WriteLine();
            auntenticado(user);
        }
        //Funcion para registrarse.
        public static void registrarse()
        {
            long user;
            int password;            
                    Console.Write("Digite su numero de Cedula para el usuario:");
                    user = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Digite su contraseña:");
                    password = Convert.ToInt32(Console.ReadLine());
           
                    Empleados empleado4 = new Empleados()
                    {
                        nombre = "Vacio",
                        Fecha_creac = DateTime.Today,
                        actividad = false,
                        rol = "VENDEDOR",

                    };
                    Console.WriteLine("Digite su nombre completo:");
                    empleado4.nombre = Console.ReadLine();

                    Console.WriteLine("Su usuario ha sido creado sastifactoriamente, ahora mismo usted esta desactivado, si desea activar su usuario presione S, sino, presione ENTER.");
                    string tecla = Console.ReadLine();
                    if (tecla == "s" || tecla == "S")
                    {
                        empleado4.actividad = true;

                    }
                    if (empleado4.actividad == true)
                    {
                        Console.WriteLine("Buenos dias, usted ha accedido con el usuario de {0}", empleado4.nombre);
                        Console.WriteLine("Tiene el rol de {0}", empleado4.rol);
                        Console.WriteLine("Este usuario fue creado en la fecha: {0}", empleado4.Fecha_creac);
                
                    }
                    else { Console.WriteLine("El usuario de {0} esta inactivo, por favor hablar con un administrador para activarlo.", empleado4.nombre);
                autenticacion();
            }
        }
        //Funcion para mostrar los datos despues de autenticado.
       public static void auntenticado(long usuario) 
       {
            //EMPLEADO 1
            Empleados empleado1 = new Empleados()
            {
                nombre = "Lemuel Acosta Castro",
                Fecha_creac = new DateTime(2001, 5, 23),
                actividad = true,
                rol = "SUPERVISOR",
            };

            //EMPLEADO 2 
            Empleados empleado2 = new Empleados()
            {
                nombre = "Ramon Caceres Diaz",
                Fecha_creac = new DateTime(2006, 8, 14),
                actividad = true,
                rol = "ADMINISTRADOR",
            };

            //EMPLEADO 3
            Empleados empleado3 = new Empleados()
            {
                nombre = "Lucas Enrique Gaviria Acosta",
                Fecha_creac = new DateTime(2008, 9, 12),
                actividad = false,
                rol = "VENDEDOR",

            };

            switch (usuario)
            {
                case 12300115204:
                    if (empleado1.actividad == true)
                    {
                        Console.WriteLine("Buenos dias, usted ha accedido con el usuario de {0}", empleado1.nombre);
                        Console.WriteLine("Tiene el rol de {0}", empleado1.rol);
                        Console.WriteLine("Este usuario fue creado en la fecha: {0}", empleado1.Fecha_creac);
                    }
                    else { Console.WriteLine("El usuario de {0} esta inactivo, por favor hablar con un administrador para activarlo.", empleado1.nombre);
                        autenticacion();
                    }
                    break;

                case 40258324500:
                    if (empleado2.actividad == true)
                    {
                        Console.WriteLine("Buenos dias, usted ha accedido con el usuario de {0}", empleado2.nombre);
                        Console.WriteLine("Tiene el rol de {0}", empleado2.rol);
                        Console.WriteLine("Este usuario fue creado en la fecha: {0}", empleado2.Fecha_creac);
                    }
                    else { Console.WriteLine("El usuario de {0} esta inactivo, por favor hablar con un administrador para activarlo.", empleado2.nombre);
                        autenticacion();
                    }
                    break;

                case 40234533211:
                    if (empleado3.actividad == true)
                    {
                        Console.WriteLine("Buenos dias, usted ha accedido con el usuario de {0}", empleado3.nombre);
                        Console.WriteLine("Tiene el rol de {0}", empleado3.rol);
                        Console.WriteLine("Este usuario fue creado en la fecha: {0}", empleado3.Fecha_creac);
                    }
                    else { Console.WriteLine("El usuario de {0} esta inactivo, por favor hablar con un administrador para activarlo.", empleado3.nombre);
                        autenticacion();
                    }
                    break;
            }
        }
        static void Main(string[] args)
        {
            autenticacion();           
        }
    }
}
