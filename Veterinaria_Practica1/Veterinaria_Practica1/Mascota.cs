using System;

namespace clasePadre
{
    public abstract class Mascota
    {
        public string Nombre { get; set; }
        public double Peso { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Propietario { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }

        public Mascota(string nombre, double peso, string sexo, int edad, string propietario, string estado)
        {
            Nombre = nombre;
            Peso = peso;
            Sexo = sexo;
            Edad = edad;
            Propietario = propietario;
            Estado = estado;
            Codigo = GenerarCodigoUnico();
        }
        private string GenerarCodigoUnico()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] codigo = new char[8];
            for (int i = 0; i < 8; i++)
            {
                codigo[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new string(codigo);
        }

        public virtual double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg;
        }

        public void CambiarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("---------INFORME DE MASCOTA-----------");
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Peso: " + Peso + "kg");
            Console.WriteLine("Sexo: " + Sexo);
            Console.WriteLine("Edad: " + Edad + " años");
            Console.WriteLine("Propietario: " + Propietario);
            Console.WriteLine("Estado: " + Estado);
        }
    }
}

namespace clasesHijas
{
    using clasePadre;

    // /////////////////////// PERRO /////////////////////////
    public class Perro : Mascota
    {
        public string Raza { get; set; }
        public string Tamano { get; set; }

        public Perro(string nombre, double peso, string sexo, int edad, string propietario, string estado, string raza, string tamano)
            : base(nombre, peso, sexo, edad, propietario, estado)
        {
            Raza = raza;
            Tamano = tamano;
        }

        public override double CalcularDosis(double dosisPorKg)
        {
            return base.CalcularDosis(dosisPorKg);
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("PERRO");
            Console.WriteLine("Raza: " + Raza);
            Console.WriteLine("Tamaño: " + Tamano);
        }
    }

    // /////////////////////// GATO /////////////////////////
    public class Gato : Mascota
    {
        public string Raza { get; set; }
        public bool Esterilizado { get; set; }

        public Gato(string nombre, double peso, string sexo, int edad, string propietario, string estado, string raza, bool esterilizado)
            : base(nombre, peso, sexo, edad, propietario, estado)
        {
            Raza = raza;
            Esterilizado = esterilizado;
        }

        public override double CalcularDosis(double dosisPorKg)
        {
            double dosisBase = base.CalcularDosis(dosisPorKg);
            return dosisBase * 0.90;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("GATO");
            Console.WriteLine("Raza: " + Raza);
            Console.WriteLine("Esterilizado: " + (Esterilizado ? "Sí" : "No"));
        }
    }

    // /////////////////////// AVE /////////////////////////
    public class Ave : Mascota
    {
        public double EnvergaduraAlas { get; set; }
        public bool PuedeVolar { get; set; }

        public Ave(string nombre, double peso, string sexo, int edad, string propietario, string estado, double envergaduraAlas, bool puedeVolar)
            : base(nombre, peso, sexo, edad, propietario, estado)
        {
            EnvergaduraAlas = envergaduraAlas;
            PuedeVolar = puedeVolar;
        }

        public override double CalcularDosis(double dosisPorKg)
        {
            double dosisBase = base.CalcularDosis(dosisPorKg);
            return dosisBase * 0.50;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("AVE");
            Console.WriteLine("Envergadura: " + EnvergaduraAlas + "cm");
            Console.WriteLine("Puede volar: " + (PuedeVolar ? "Sí" : "No"));
        }
    }

    // ////////////////////// TORTUGA ////////////////////////////
    public class Tortuga : Mascota
    {
        public string TipoCaparazon { get; set; }
        public bool Acuatica { get; set; }

        public Tortuga(string nombre, double peso, string sexo, int edad, string propietario, string estado, string tipoCaparazon, bool esAcuatica) : base(nombre, peso, sexo, edad, propietario, estado)
        {
            TipoCaparazon = tipoCaparazon;
            Acuatica = esAcuatica;
        }

        public override double CalcularDosis(double dosisPorKg)
        {
            double dosisBase = base.CalcularDosis(dosisPorKg);
            return dosisBase * 0.80;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("TORTUGA");
            Console.WriteLine("Caparazón: " + TipoCaparazon);
            Console.WriteLine("Acuática: " + (Acuatica ? "Sí" : "No"));
        }
    }
}