﻿using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using TopLanches.Areas.Admin.FastReportUtils;
using TopLanches.Areas.Admin.Servicos;

namespace TopLanches.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLanchesReportController : Controller
{
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly RelatorioLanchesService _relatorioLanchesService;

    public AdminLanchesReportController(IWebHostEnvironment webHostEnv, RelatorioLanchesService relatorioLanchesService)
    {
        _webHostEnv = webHostEnv;
        _relatorioLanchesService = relatorioLanchesService;
    }

    public async Task<ActionResult> AdminLanchesCategoriaReport()
    {
        var webReport = new WebReport();
        var mssqlDataConnection = new MsSqlDataConnection();

        webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports","LanchesCategoria.frx"));

        var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(), "LanchesReport");
        var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(), "CategoriasReport");

        webReport.Report.RegisterData(lanches, "LanchesReport");
        webReport.Report.RegisterData(categorias, "CategoriasReport");
        return View(webReport);
    }

    [Route("LanchesCategoriaPDF")]
    public async Task<ActionResult> AdminLanchesCategoriaPDF()
    {
        var webReport = new WebReport();
        var mssqlDataConnection = new MsSqlDataConnection();

        webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "LanchesCategoria.frx"));

        var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(), "LanchesReport");
        var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(), "CategoriasReport");

        webReport.Report.RegisterData(lanches, "LanchesReport");
        webReport.Report.RegisterData(categorias, "CategoriasReport");

        webReport.Report.Prepare();

        Stream stream = new MemoryStream();

        webReport.Report.Export(new PDFSimpleExport(), stream);
        stream.Position = 0;

        //return File(stream, "application/zip", "LancheCategoria.pdf");

        return new FileStreamResult(stream, "application/pdf");
    }
}
