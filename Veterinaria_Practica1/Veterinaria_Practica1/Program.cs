using System;
using clasePadre;
using clasesHijas;

internal class Program
{
    static void Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("BIENVENIDO AL SISTEMA DE LA VETERINARIA ");

        Mascota mascota = RegistrarMascota();
        Console.Clear();

        Console.WriteLine("\n¡Mascota registrada con éxito!");
        mascota.MostrarInformacion();

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("\n--------- MENÚ PRINCIPAL ---------");
            Console.WriteLine("1. Calcular dosis de medicamento");
            Console.WriteLine("2. Cambiar de estado (Enfermo/Sano)");
            Console.WriteLine("3. Información completa");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string op = Console.ReadLine();
            Console.Clear();

            switch (op)
            {
                case "1":
                    CalcularDosis(mascota);
                    break;

                case "2":
                    CambiarEstado(mascota);
                    break;

                case "3":
                    mascota.MostrarInformacion();
                    break;

                case "4":
                    Console.WriteLine("Cerrando el programa...");
                    loop = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }

    static Mascota RegistrarMascota()
    {
        Console.WriteLine("Seleccione el tipo de mascota a registrar:");
        Console.WriteLine("1. Perro");
        Console.WriteLine("2. Gato");
        Console.WriteLine("3. Ave");
        Console.WriteLine("4. Tortuga");
        Console.Write("Opción: ");
        string tipo = Console.ReadLine();

        Console.Write("\nNombre: ");
        string nombre = Console.ReadLine();

        double peso = LeerDouble("Peso (kg): ");

        Console.Write("Sexo (Macho/Hembra): ");
        string sexo = Console.ReadLine();

        int edad = LeerEntero("Edad (años): ");

        Console.Write("Nombre de Propietario: ");
        string propietario = Console.ReadLine();

        Console.Write("Estado actual (Sano/Enfermo): ");
        string estado = Console.ReadLine();

        switch (tipo)
        {
            case "1":
                Console.Write("Raza: ");
                string raza = Console.ReadLine();
                Console.Write("Tamaño (Pequeño/Mediano/Grande): ");
                string tamano = Console.ReadLine();
                return new Perro(nombre, peso, sexo, edad, propietario, estado, raza, tamano);

            case "2":
                Console.Write("Raza: ");
                string razaGato = Console.ReadLine();
                bool esterilizado = LeerBool("¿Está esterilizado? (s/n): ");
                return new Gato(nombre, peso, sexo, edad, propietario, estado, razaGato, esterilizado);

            case "3":
                double envergadura = LeerDouble("Envergadura de alas (cm): ");
                bool puedeVolar = LeerBool("Puede volar? (s/n): ");
                return new Ave(nombre, peso, sexo, edad, propietario, estado, envergadura, puedeVolar);

            case "4":
                Console.Write("Tipo de caparazón: ");
                string caparazon = Console.ReadLine();
                bool esAcuatica = LeerBool("Es acuática? (s/n): ");
                return new Tortuga(nombre, peso, sexo, edad, propietario, estado, caparazon, esAcuatica);

            default:
                Console.WriteLine("Opción inválida, se registrará como Perro por defecto.");
                return new Perro(nombre, peso, sexo, edad, propietario, estado, "Sin especificar", "Sin especificar");
        }
    }
    // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static void CalcularDosis(Mascota mascota)
    {
        double dosisPorKg = LeerDouble("Ingrese la dosis por kg del medicamento (mg/kg): ");
        double resultado = mascota.CalcularDosis(dosisPorKg);
        Console.WriteLine($"Dosis total a administrar: {resultado:F2} mg");
    }

    static void CambiarEstado(Mascota mascota)
    {
        Console.Write("Nuevo estado (Sano/Enfermo): ");
        string nuevoEstado = Console.ReadLine();
        mascota.CambiarEstado(nuevoEstado);
        Console.WriteLine($"Estado actualizado a: {mascota.Estado}");
    }


    // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static double LeerDouble(string mensaje)
    {
        double valor;
        Console.Write(mensaje);
        while (!double.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido. Ingrese un número: ");
        }
        return valor;
    }

    static int LeerEntero(string mensaje)
    {
        int valor;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido. Ingrese un número entero: ");
        }
        return valor;
    }

    static bool LeerBool(string mensaje)
    {
        Console.Write(mensaje);
        string respuesta = Console.ReadLine()?.Trim().ToLower();
        return respuesta == "s" || respuesta == "si" || respuesta == "sí";
    }
}