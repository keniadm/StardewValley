using Stardew.Models;
using System.Text.Json;

namespace Stardew.Services;

public class ColheService : IColheService
{
    private readonly IHttpContextAccessor _session;
    private readonly string colheitaFile = @"Data\colheitas.json";
    private readonly string tiposFile = @"Data\tipos.json";

    public ColheService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Colheita> GetColheitas()
    {
        PopularSessao();
        var colheitas = JsonSerializer.Deserialize<List<Colheita>>
            (_session.HttpContext.Session.GetString("Colheitas"));
        return colheitas;
    }

    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }

    public Colheita GetColheita(int Numero)
    {
        var colheitas = GetColheitas();
        return colheitas.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public StardewDto GetStardewDto()
    {
        var colher = new StardewDto()
        {
            Colheitas = GetColheitas(),
            Tipos = GetTipos()
        };
        return colher;
    }

    public DetailsDto GetDetailedColheita(int Numero)
    {
        var colheitas = GetColheitas();
        var colhe = new DetailsDto()
        {
            Current = colheitas.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
            Prior = colheitas.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
            Next = colheitas.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero),
        };
        return colhe;
    }

    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session.SetString("Colheitas", LerArquivo(colheitaFile));
            _session.HttpContext.Session.SetString("Tipos", LerArquivo(tiposFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}