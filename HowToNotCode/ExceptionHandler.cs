using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToNotCode
{
    public class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
           
        }

        public static void HandleValidationException(ValidationException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
            
        }
    }
}
