using System;
// Clase Persona que representa los datos necesarios para el cálculo del IMC
// CLASE PERSONA - Calculadora IMC

namespace CalculadoraIMC
{
    public class Persona
    {
        // Atributos públicos
        public string Nombre;
        public double Peso;
        public double Altura;
        public int Edad;
        public string Genero;

        // Constructor
        public Persona(string nombre, double peso, double altura, int edad, string genero)
        {
            Nombre = nombre;
            Peso = peso;
            Altura = altura;
            Edad = edad;
            Genero = genero;
        }

        // Método para calcular IMC
        public double CalcularIMC()
        {
            if (Altura <= 0)
            {
                throw new Exception("La altura debe ser mayor a 0");
            }
            
            double imc = Peso / (Altura * Altura);
            return Math.Round(imc, 2);
        }

        // Método para mostrar resultados
        public void MostrarResultados()
        {
            double imc = CalcularIMC();
            string categoria = "";
            string riesgo = "";

            // Clasificación según IMC
            if (imc < 18.5)
            {
                categoria = "Bajo peso";
                riesgo = "Riesgo de deficiencias nutricionales, anemia y osteoporosis";
            }
            else if (imc < 25)
            {
                categoria = "Normal";
                riesgo = "Riesgo bajo; estado saludable";
            }
            else if (imc < 30)
            {
                categoria = "Sobrepeso";
                riesgo = "Riesgo aumentado de enfermedades cardiovasculares, hipertensión y diabetes";
            }
            else if (imc < 35)
            {
                categoria = "Obesidad Tipo I (moderada)";
                riesgo = "Riesgo alto de diabetes tipo 2, hipertensión y problemas cardiovasculares";
            }
            else if (imc < 40)
            {
                categoria = "Obesidad Tipo II (severa)";
                riesgo = "Riesgo muy alto de complicaciones graves: infartos, apnea del sueño, artrosis";
            }
            else
            {
                categoria = "Obesidad Tipo III (mórbida)";
                riesgo = "Riesgo extremadamente alto: enfermedades cardiovasculares, metabólicas y mayor mortalidad";
            }

            // Mostrar resultados
            Console.WriteLine("\n==================================================");
            Console.WriteLine("           RESULTADOS DEL CALCULO DE IMC");
            Console.WriteLine("==================================================");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Altura: {Altura} m");
            Console.WriteLine($"IMC calculado: {imc}");
            Console.WriteLine($"Composición corporal: {categoria}");
            Console.WriteLine($"Riesgo asociado: {riesgo}");
        }
    }
}


// posteriormente en otros archivos  pondre las vadilaciones y programa principal "" 