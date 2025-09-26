using System;
// Clase Persona que representa los datos necesarios para el cálculo del IMC

namespace CalculadoraIMC
{
    public class Persona
    {
        // Características de la persona (atributos)
        public string Nombre;
        public double Peso;      // en kilogramos
        public double Altura;    // en metros
        public int Edad;
        public string Genero;

        // Constructor - para crear nuevas personas
        public Persona(string nombre, double peso, double altura, int edad, string genero)
        {
            // Usamos las validaciones del archivo separado
            Nombre = Validaciones.ValidarSoloLetras(nombre, "nombre"); // SOLO LETRAS
            Peso = Validaciones.ValidarNumero(peso, "peso", 300);
            Altura = Validaciones.ValidarNumero(altura, "altura", 3);
            Edad = Validaciones.ValidarEdad(edad);
            Genero = Validaciones.ValidarTexto(genero, "género"); // Puede contener números si es necesario
        }
// Método para calcular el índice de masa corporal
        // Método para calcular el IMC
        public double CalcularIMC()
        {
            // Fórmula: peso / (altura × altura)
            double imc = Peso / (Altura * Altura);
            return Math.Round(imc, 2);  // Redondear a 2 decimales
        }

        // Método para mostrar los resultados
        public void MostrarResultados()
        {
            double imc = CalcularIMC();
            
            // Determinar la categoría según el IMC
            string categoria = "";
            string riesgo = "";

            if (imc < 18.5)
            {
                categoria = "Bajo peso";
                riesgo = "Riesgo de deficiencias nutricionales, anemia y osteoporosis";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                categoria = "Normal";
                riesgo = "Riesgo bajo; estado saludable";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                categoria = "Sobrepeso";
                riesgo = "Riesgo aumentado de enfermedades cardiovasculares, hipertension y diabetes";
            }
            else if (imc >= 30 && imc <= 34.9)
            {
                categoria = "Obesidad Tipo I (moderada)";
                riesgo = "Riesgo alto de diabetes tipo 2, hipertension y problemas cardiovasculares";
            }
            else if (imc >= 35 && imc <= 39.9)
            {
                categoria = "Obesidad Tipo II (severa)";
                riesgo = "Riesgo muy alto de complicaciones graves: infartos, apnea del sueño, artrosis";
            }
            else
            {
                categoria = "Obesidad Tipo III (morbida)";
                riesgo = "Riesgo extremadamente alto: enfermedades cardiovasculares, metabolicas y mayor mortalidad";
            }

            // Mostrar resultados en pantalla
            Console.WriteLine("\n==================================================");
            Console.WriteLine("           RESULTADOS DEL CALCULO DE IMC");
            Console.WriteLine("==================================================");
            
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad + " años");
            Console.WriteLine("Genero: " + Genero);
            Console.WriteLine("Peso: " + Peso + " kg");
            Console.WriteLine("Altura: " + Altura + " m");
            Console.WriteLine("IMC calculado: " + imc);
            Console.WriteLine("Composicion corporal: " + categoria);
            Console.WriteLine("Riesgo asociado: " + riesgo);
        }
    }
}