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

        // Método para pedir el nombre - SOLO LETRAS
        static string PedirNombre()
        {
            while (true)
            {
                try
                {
                    Console.Write("1. Cual es tu nombre? ");
                    string nombre = Console.ReadLine();
                    return Validaciones.ValidarSoloLetras(nombre, "nombre");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir el peso - AHORA ACEPTA PUNTOS Y COMAS
        static double PedirPeso()
        {
            while (true)
            {
                try
                {
                    Console.Write("2. Cuanto pesas en kilogramos? (ejemplo: 75.5 o 75,5) ");
                    string texto = Console.ReadLine();
                    double peso = Validaciones.TextoANumero(texto, "peso");
                    return Validaciones.ValidarNumero(peso, "peso", 300);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // Método para pedir la altura - AHORA ACEPTA PUNTOS Y COMAS
        static double PedirAltura()
        {
            while (true)
            {
                try
                {
                    Console.Write("3. Cuanto mides en metros? (ejemplo: 1.75 o 1,75) ");
                    string texto = Console.ReadLine();
                    
                    // Si el usuario escribe la altura en centímetros (ej: 175), la convertimos a metros
                    texto = texto.Replace(',', '.'); // Asegurar que usamos punto decimal
                    
                    if (double.TryParse(texto, out double alturaCm) && alturaCm > 10 && alturaCm < 300)
                    {
                        // Si el número está entre 10 y 300, probablemente son centímetros
                        double alturaMetros = alturaCm / 100;
                        Console.WriteLine("Nota: Se interpreto " + alturaCm + " cm como " + alturaMetros + " m");
                        return Validaciones.ValidarNumero(alturaMetros, "altura", 3);
                    }
                    
                    double altura = Validaciones.TextoANumero(texto, "altura");
                    return Validaciones.ValidarNumero(altura, "altura", 3);
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
                    Console.Write("4. Cuantos anos tienes? ");
                    string texto = Console.ReadLine();
                    int edad = Validaciones.TextoANumeroEntero(texto, "edad");
                    return Validaciones.ValidarEdad(edad);
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
                    Console.Write("5. Cual es tu genero? ");
                    string genero = Console.ReadLine();
                    return Validaciones.ValidarTexto(genero, "genero");
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