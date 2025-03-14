using Microsoft.AspNetCore.Mvc;

public class CreditoController : Controller
{
    [HttpGet]
    public IActionResult Solicitar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Solicitar(SolicitudCredito solicitud)
    {
        if (!ModelState.IsValid)
        {
            return View(solicitud);
        }

        var (aprobado, mensaje) = solicitud.EvaluarCredito();

        ViewBag.Resultado = mensaje;
        ViewBag.Aprobado = aprobado;

        return View(solicitud);
    }
}
