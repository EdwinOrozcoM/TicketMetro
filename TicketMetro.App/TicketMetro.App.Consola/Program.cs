// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TicketMetro.App.Dominio;
using TicketMetro.App.Persistencia;
namespace TicketMetro.App.Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool entrada = true;
            
            while (entrada)
            {
                var objContexto = new Contexto();// este obj que me va apermitir las operacione sobre BD y cuando hay una exception en los try() catch la excepcion no me permite ya seguirel programa con el codigo actual por eso se mete denuevo en el ciclo while 
                Console.WriteLine("Ingrese la opcion");
                Console.WriteLine("1. Ingresar estación ");
                Console.WriteLine("2. Ingresar persona");
                Console.WriteLine("3. Ingresar ticket ");
                Console.WriteLine("4. Consultar personas ");
                Console.WriteLine("5. Consultar estaciones ");
                Console.WriteLine("6. Consultar tickets ");
                Console.WriteLine("7. Salir ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre de la Estacion");
                        string nombreEstacion = Console.ReadLine();
                        Console.WriteLine("Ingrese la latitud");
                        double latitudEstacion = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese la longitud");
                        double longitudEstacion = Convert.ToDouble(Console.ReadLine());

                        Estacion objEstacion = new Estacion()
                        {
                            nombre = nombreEstacion,
                            latitud = latitudEstacion,
                            longitud = longitudEstacion

                        };


                        objContexto.Add(objEstacion);
                        objContexto.SaveChanges();


                        break;
                    case 2:
                        Console.WriteLine("Ingrese la cedula de la persona");
                        int cedula = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la Persona");
                        string nombrePersona = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona");
                        string apellidoPersona = Console.ReadLine();
                        Console.WriteLine("Ingrese la direcion");
                        string direccionPersona = Console.ReadLine();

                        Persona objPersona = new Persona()
                        {
                            nombre = nombrePersona,
                            apellido = apellidoPersona,
                            direccion = direccionPersona,
                            cedula = cedula
                        };
                        try 
                        {
                            objContexto.Add(objPersona);
                            objContexto.SaveChanges();

                         }
                        catch (Exception y)
                        {
                            Console.WriteLine("Error en Ingreso de sedula.."+y);

                        };

                        break;
                    case 3:

                        try
                        {
                            Console.WriteLine("Ingrese la cedula de la Persona");
                            int personaBuscar = Convert.ToInt32(Console.ReadLine());

                            var persona = objContexto.Personas.Where(p => p.cedula == personaBuscar).Single();// p es una variable por convencion del metodo que me mapea la tabla Personas // Single() para que medevuelva solamente una
                            Console.WriteLine("Nombre " + persona.nombre + " Apellido " + persona.apellido + " Direccion " + persona.direccion);

                            Console.WriteLine("Ingrese el nombre de la Estacion Inicial");
                            string estacionInicialBuscar = Console.ReadLine();

                            var estacion_inicial = objContexto.Estaciones.Where(e => e.nombre == estacionInicialBuscar).Single();

                            Console.WriteLine("Ingrese el nombre de la Estacion final");
                            string estacionFinalBuscar = Console.ReadLine();

                            var estacion_final = objContexto.Estaciones.Where(e => e.nombre == estacionFinalBuscar).Single();

                            Console.WriteLine("Ingrese el precio (int) del ticket");
                            int precio = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Ingrese el año de compra del ticket");
                            int anio_ticket = Convert.ToInt32(Console.ReadLine());


                            Console.WriteLine("Ingrese el mes de compra del ticket");
                            int mes_ticket = Convert.ToInt32(Console.ReadLine());


                            Console.WriteLine("Ingrese el año de compra del ticket");
                            int dia_ticket = Convert.ToInt32(Console.ReadLine());

                            DateTime fecha_ticket = new DateTime(anio_ticket, mes_ticket, dia_ticket);

                            Ticket objBoleto = new Ticket()
                            {
                                objPerosna = persona,
                                objEstacionInicial = estacion_inicial,
                                objEstacionFinal = estacion_final,
                                precion = precio,
                                fecha = fecha_ticket
                            };

                            objContexto.Add(objBoleto);
                            objContexto.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("El dato no existe..  " + e);
                        }

                        break;
                    case 4:
                        var personas = objContexto.Personas;
                        foreach (var usuario in personas)
                        {
                            Console.WriteLine("Nombre :" + usuario.nombre + " Apellido :" + usuario.apellido + " Direccón :" + usuario.direccion);
                        }
                        break;
                    case 5:
                        var estaciones = objContexto.Estaciones;
                        foreach (var estacion in estaciones)
                        {
                            Console.WriteLine("Nombre estacion :" + estacion.nombre + " Latitud :" + estacion.latitud + " Longitud :" + estacion.longitud);
                        }

                        break;
                    case 6:
                        var tickets = objContexto.Tickets.Include("objPerosna").Include("objEstacionInicial").Include("objEstacionFinal");//el.Include me permite traer los obj que tinen lod Id  por que en la tabla Ticket se guardan es los Id de persona y estacion y con incluede me trae los objetos asociados a los ID, debe adicionar Microsoft.EntityFrameworkCore
                        foreach (var ticket in tickets)
                        {
                            Console.WriteLine(" Persona " + ticket.objPerosna + " Estacion Inicial " + ticket.objEstacionInicial + " Estacion Final " + ticket.objEstacionFinal + " Fecha ticket" + ticket.fecha);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del menu..");
                        entrada = false;
                        break;

                    default:
                        Console.WriteLine("Ingrese la opcion");
                        break;
                }
            }
        }

    }
}