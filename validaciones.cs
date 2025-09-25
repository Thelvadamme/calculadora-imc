using System;

namespace CalculadoraIMC
{
    public static class Validaciones
    {
        // Validar que un texto solo contenga letras y espacios
        public static string ValidarSoloLetras(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new Exception($"Error: El {nombreCampo} no puede estar vacío");
            }

            // Verificar que solo contenga letras y espacios
            foreach (char caracter in texto)
            {
                if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                {
                    throw new Exception($"Error: El {nombreCampo} solo puede contener letras y espacios");
                }
            }

            return texto.Trim();
        }

        // Validar que un texto no esté vacío (para género)
        public static string ValidarTexto(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new Exception($"Error: El {nombreCampo} no puede estar vacío");
            }
            return texto.Trim();
        }

        // Validar que un número sea positivo y esté en rango razonable
        public static double ValidarNumero(double numero, string nombreCampo, double maximo)
        {
            if (numero <= 0)
            {
                throw new Exception($"Error: El {nombreCampo} debe ser mayor a 0");
            }
            
            if (numero > maximo)
            {
                throw new Exception($"Error: El {nombreCampo} no puede ser mayor a {maximo}");
            }
            
            return numero;
        }

        // Validar la edad
        public static int ValidarEdad(int edad)
        {
            if (edad < 0 || edad > 150)
            {
                throw new Exception("Error: La edad debe estar entre 0 y 150 años");
            }
            return edad;
        }

        // Convertir texto a número con validación - AHORA ACEPTA PUNTOS Y COMAS
        public static double TextoANumero(string texto, string nombreCampo)
        {
            // Reemplazar coma por punto para aceptar ambos formatos
            texto = texto.Replace(',', '.');
            
            if (!double.TryParse(texto, out double resultado))
            {
                throw new Exception($"Error: El {nombreCampo} debe ser un número válido (ejemplo: 75.5 o 75,5)");
            }
            return resultado;
        }

        // Convertir texto a número entero
        public static int TextoANumeroEntero(string texto, string nombreCampo)
        {
            if (!int.TryParse(texto, out int resultado))
            {
                throw new Exception($"Error: El {nombreCampo} debe ser un número entero válido");
            }
            return resultado;
        }
    }
}