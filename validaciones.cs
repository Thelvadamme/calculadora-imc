using System;
using System.Globalization;
namespace CalculadoraIMC
{
    public static class Validaciones
    {
        // Validar que no esté vacío
        public static string ValidarNoVacio(string entrada, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(entrada))
            {
                throw new Exception($"Error: El {nombreCampo} no puede estar vacío");
            }
            return entrada.Trim();
        }

        // Validar número decimal
// Validar número decimal
public static double ValidarNumeroDecimal(string entrada, string nombreCampo, double maximo)
{
    // Reemplazar coma por punto para aceptar ambos formatos
    entrada = entrada.Trim().Replace(',', '.');
    
    // Usar CultureInfo.InvariantCulture para parsear correctamente
    if (!double.TryParse(entrada, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double numero))
    {
        throw new Exception($"Error: El {nombreCampo} debe ser un número válido (ejemplo: 64.40)");
    }
    
    if (numero <= 0)
    {
        throw new Exception($"Error: El {nombreCampo} debe ser mayor a 0");
    }
    
    // CORREGIDO: Cambiar > por >=
    if (numero >= maximo)
    {
        throw new Exception($"Error: El {nombreCampo} no puede ser mayor a {maximo}");
    }
    
    return numero;
}
        // Validar edad
        public static int ValidarEdad(string entrada)
        {
            if (!int.TryParse(entrada, out int edad))
            {
                throw new Exception("Error: La edad debe ser un número entero válido");
            }
            
            if (edad < 0 || edad > 150)
            {
                throw new Exception("Error: La edad debe estar entre 0 y 150 años");
            }
            
            return edad;
        }
    }
}