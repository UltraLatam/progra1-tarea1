using System;
using System.ComponentModel.DataAnnotations;

public class SolicitudCredito
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public required string Nombres { get; set; } 

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 dígitos.")]
    public required string DNI { get; set; }

    [Required(ErrorMessage = "Ingrese la fecha")]
    [DataType(DataType.Date)]
    public DateTime FechaContratacion { get; set; }

    [Required(ErrorMessage = "El salario es obligatorio.")]
    [Range(1, double.MaxValue, ErrorMessage = "El salario debe ser mayor a 0.")]
    public decimal Salario { get; set; }

    [Required(ErrorMessage = "Debe seleccionar la frecuencia de pago.")]
    public required string FrecuenciaPago { get; set; }

    [Required(ErrorMessage = "Ingrese el monto solicitado.")]
    [Range(1, double.MaxValue, ErrorMessage = "El monto solicitado debe ser mayor a 0.")]
    public decimal MontoSolicitado { get; set; }

    // Método para verificar si el crédito es aprobado o no
    public (bool, string) EvaluarCredito()
    {
        // Calcular el tiempo de contratación
        var mesesTrabajados = (DateTime.Now - FechaContratacion).Days / 30;

        // Regla: debe tener al menos 3 meses de contratación
        if (mesesTrabajados < 3)
            return (false, "Rechazado: Debe tener al menos 3 meses de contratación.");

        // Regla: No puede solicitar más del 30% de su salario
        if (MontoSolicitado > (Salario * 0.3m))
            return (false, "Rechazado: No puede solicitar más del 30% de su salario.");

        // Regla: Si el salario es mayor a 2000 y la frecuencia es quincenal o mensual, se aprueba
        if (Salario > 2000 && (FrecuenciaPago == "Quincenal" || FrecuenciaPago == "Mensual"))
            return (true, "Aprobado: Cumple con las condiciones de salario y frecuencia de pago.");

        // Regla: Si el salario es menor a 2000 y la frecuencia es semanal, se aprueba
        if (Salario <= 2000 && FrecuenciaPago == "Semanal")
            return (true, "Aprobado: Su salario es menor a 2000 y su frecuencia de pago es semanal.");

        // Si no cumple ninguna condición, se rechaza
        return (false, "Rechazado: No cumple con los requisitos para otorgar el crédito.");
    }
}
