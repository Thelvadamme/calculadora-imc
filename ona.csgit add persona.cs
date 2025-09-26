[1mdiff --git a/persona.cs b/persona.cs[m
[1mindex 88a897c..aecdd75 100644[m
[1m--- a/persona.cs[m
[1m+++ b/persona.cs[m
[36m@@ -1,4 +1,5 @@[m
 using System;[m
[32m+[m[32m// Clase Persona que representa los datos necesarios para el cálculo del IMC[m
 [m
 namespace CalculadoraIMC[m
 {[m
[36m@@ -21,7 +22,7 @@[m [mnamespace CalculadoraIMC[m
             Edad = Validaciones.ValidarEdad(edad);[m
             Genero = Validaciones.ValidarTexto(genero, "género"); // Puede contener números si es necesario[m
         }[m
[31m-[m
[32m+[m[32m// Método para calcular el índice de masa corporal[m
         // Método para calcular el IMC[m
         public double CalcularIMC()[m
         {[m
