using Stardew.Models;

namespace Stardew.Services;

public interface IColheService
{
    List<Colheita> GetColheitas();
    List<Tipo> GetTipos();
    Colheita GetColheita(int Numero);
    StardewDto GetStardewDto();
    DetailsDto GetDetailedColheita(int Numero);
    Tipo GetTipo(string Nome);
}