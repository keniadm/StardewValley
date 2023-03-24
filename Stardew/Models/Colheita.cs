namespace Stardew.Models
{
    public class Colheita
    {
        // Atributos
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public List<string> Tipo { get; set; }
        public string Dias { get; set; }
        public double Maximo { get; set; }
        public string Vende { get; set; }
        public string Imagem { get; set; }

        // Método Construtor
        public Colheita()
        {
            Tipo = new List<string>();
        }
    }
}