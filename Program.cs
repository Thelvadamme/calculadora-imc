using System;

namespace CalculadoraIMC
{
    class Program
    {
        // Método principal - donde empieza el programa
        static void Main(string[] args)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("          CALCULADORA DE IMC - POO");
            Console.WriteLine("================================================");
            Console.WriteLine("");
            Console.WriteLine("Vamos a calcular tu Indice de Masa Corporal (IMC)");
            Console.WriteLine("Por favor, ingresa tus datos:");
            Console.WriteLine("");

            try
            {
                // Pedir cada dato al usuario
                string nombre = PedirNombre();
                double peso = PedirPeso();
                double altura = PedirAltura();
                int edad = PedirEdad();
                string genero = PedirGenero();

                // Crear un objeto Persona con los datos
                Persona usuario = new Persona(nombre, peso, altura, edad, genero);

                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Calculando IMC...");
                Console.WriteLine("--------------------------------------------------");

                // Mostrar los resultados
                usuario.MostrarResultados();

                // Mostrar recomendación final
                MostrarRecomendacion(usuario.CalcularIMC());
            }
            catch (Exception error)
            {
                Console.WriteLine("");
                Console.WriteLine("ERROR: " + error.Message);
                Console.WriteLine("Por favor, inicia el programa nuevamente.");
            }

            Console.WriteLine("");
            Console.WriteLine("==================================================");
            Console.WriteLine("Gracias por usar la calculadora de IMC!");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método para pedir el nombre
        static string PedirNombre()
        {
            while (true)
            {
                try
                {
                    Console.Write("1. ¿Cuál es tu nombre? ");
                    string entrada = Console.ReadLine();
                    return Validaciones.ValidarNoVacio(entrada, "nombre");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir el peso - SOLO NÚMEROS
        static double PedirPeso()
        {
            while (true)
            {
                try
                {
                    Console.Write("2. ¿Cuánto pesas en kilogramos? (ejemplo: 64.40) ");
                    string entrada = Console.ReadLine();
                    return Validaciones.ValidarNumeroDecimal(entrada, "peso", 300);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir la altura
        static double PedirAltura()
        {
            while (true)
            {
                try
                {
                    Console.Write("3. ¿Cuánto mides en metros? (ejemplo: 1.75) ");
                    string entrada = Console.ReadLine();
                    
                    // Si el usuario escribe en centímetros (ej: 175)
                    entrada = entrada.Replace(',', '.');
                    if (double.TryParse(entrada, out double altura) && altura > 100 && altura < 300)
                    {
                        double alturaMetros = altura / 100;
                        Console.WriteLine($"Nota: Se interpretó {altura} cm como {alturaMetros} m");
                        return Validaciones.ValidarNumeroDecimal(alturaMetros.ToString(), "altura", 3);
                    }
                    
                    return Validaciones.ValidarNumeroDecimal(entrada, "altura", 3);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir la edad
        static int PedirEdad()
        {
            while (true)
            {
                try
                {
                    Console.Write("4. ¿Cuántos años tienes? ");
                    string entrada = Console.ReadLine();
                    return Validaciones.ValidarEdad(entrada);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir el género
        static string PedirGenero()
        {
            while (true)
            {
                try
                {
                    Console.Write("5. ¿Cuál es tu género? ");
                    string entrada = Console.ReadLine();
                    return Validaciones.ValidarNoVacio(entrada, "género");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para mostrar recomendaciones según el IMC
        static void MostrarRecomendacion(double imc)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("RECOMENDACION:");
            
            if (imc < 18.5)
            {
                Console.WriteLine("- Consulta a un nutricionista para ganar peso saludablemente");
                Console.WriteLine("- Realiza ejercicios de fuerza y come alimentos nutritivos");
            }
            else if (imc < 25)
            {
                Console.WriteLine("- Excelente! Manten tus habitos saludables");
                Console.WriteLine("- Continua con una dieta balanceada y ejercicio regular");
            }
            else if (imc < 30)
            {
                Console.WriteLine("- Considera aumentar tu actividad fisica diaria");
                Console.WriteLine("- Reduce el consumo de alimentos procesados y azucares");
            }
            else
            {
                Console.WriteLine("- Es recomendable consultar a un medico o nutricionista");
                Console.WriteLine("- Sigue un plan de alimentacion y ejercicio supervisado");
            }
        }
    }
}