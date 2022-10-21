namespace WebMinimalApiNet6.Models
{
    public record Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Feito { get; set; }
    }
}
