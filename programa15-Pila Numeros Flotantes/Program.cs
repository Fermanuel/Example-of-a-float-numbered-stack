using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa15_Pila_Numeros_Flotantes
{
    internal class Program
    {
        class Pilas
        {
            //campos de la clase
            int Max, Top, Apuntador;
            float[] Pila;
            
            //constructor de la clase
            public Pilas(int tamaño)
            {
                Max = tamaño;
                Top = -1;
                Pila = new float[tamaño];

                Console.WriteLine("\n-La pila ha sido creada con éxito.");
            }
            
            //métodos de la clase
            public void Push(float Elemento)
            {
                if (Top != Max - 1)
                {
                    Top = Top + 1;
                    Pila[Top] = Elemento;
                }
                else
                {
                    Console.WriteLine("\n-La Pila Esta Llena.");
                }
            }
            public void Pop()
            {   
                if (Top != -1)
                {
                    Console.WriteLine("\n-Dato a Eliminar: " + Pila[Top]);
                    Pila[Top] = 0;
                    Top = Top - 1;
                }
                else
                {
                    Console.WriteLine("\n-La Pila Esta vacia");
                }
            }
            public void Recorrido()
            {
                if (Top != -1)
                {
                    Apuntador = Top;

                    while (Apuntador != -1)
                    {
                        Console.WriteLine("\nA). Elemento: " + Pila[Apuntador]);
                        Console.WriteLine("B). Posicion: " + Apuntador);
                        
                        Apuntador = Apuntador - 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa Pila Esta Vacia");
                }
            }

            public void Busqueda(float Elemento)
            {
                if (Top != -1)
                {
                    Apuntador = Top;

                    while (Apuntador != -1)
                    {
                        if (Pila[Apuntador] == Elemento)
                        {
                            Console.WriteLine("\n-El elemento es: " + Elemento + "\n-Fue encontrador en la posicion: " + Apuntador);
                            return;
                        }
                        else
                        {
                            Apuntador = Apuntador - 1;
                        }
                    }
                    Console.WriteLine("\n-El Dato {0} No se Encontro en la pila",Elemento);
                }
                else
                {
                    Console.WriteLine("\n-La pila esta Vacia.");
                }
            }

            //destructor de la clase
            ~Pilas()
            {
                Console.WriteLine("\nMemoria Liberada Clase Pila");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "MENU";
            char op = 'x';

            Pilas MyPila = null;

            Stopwatch SW = new Stopwatch();
            long TotalInicio = GC.GetTotalMemory(true);

            SW.Start();
            do
            {
                Console.Clear();
                Console.WriteLine("\t-PILA Numeros Flotantes-");
                Console.WriteLine("\na) Crear la Pila.");
                Console.WriteLine("b) Insertar un Elemento.");
                Console.WriteLine("c) Eliminar el Dato del Tope.");
                Console.WriteLine("d) Recorrer la Pila.");
                Console.WriteLine("e) Buscar un Elemento.");
                Console.WriteLine("f) Salir del Programa.");
                Console.Write("\nOpcion: ");

                try
                {
                    op = char.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 'a':

                            Console.Clear();
                            Console.Write("\nIngrese Tamaño de la pila: ");
                            int numero = int.Parse(Console.ReadLine());

                            MyPila = new Pilas(numero);

                            break;
                        
                        case 'b':


                                Console.Clear();

                                Console.Write("\nInserte Numero: ");
                                float elemento = float.Parse(Console.ReadLine());

                                MyPila.Push(elemento);
 

                            break;
                        
                        case 'c':

                            Console.Clear();

                            MyPila.Pop();

                            break;

                        case 'd':

                            Console.Clear();

                            MyPila.Recorrido();

                            break;

                        case 'e':

                            Console.Clear();

                            Console.Write("\nElemnto a Buscar: ");
                            float Ebuscar = float.Parse(Console.ReadLine());

                            MyPila.Busqueda(Ebuscar);

                            break;
                        
                        case 'f':
                            Console.Title = "GRACIAS VUELVA PRONTO";

                            SW.Stop();

                            TimeSpan Ts = SW.Elapsed;
                            string ElapseTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", Ts.Hours, Ts.Minutes, Ts.Seconds, Ts.Milliseconds);
                           
                            Console.WriteLine("\nTiempo De Ejecucion: {0} Milisegundos",ElapseTime);
                              
                            long ToatalFinal = System.GC.GetTotalMemory(false);
                            
                            Console.WriteLine("\nLa Cantidad de Memoria en Bytes es: {0}",ToatalFinal - TotalInicio);
                            
                            break;
                        
                        default:
                            
                            Console.WriteLine("\nOpcion Invalida");

                            break;
                    }
                }
                catch (FormatException a)
                {
                    Console.WriteLine("\n{0}",a.Message);
                }
                finally
                {
                    Console.WriteLine("\nPresione <ENTER> Para Continuar...");
                    Console.ReadKey();
                }
            } while (op != 'f');
        }
    }
}
