namespace Todo.Model
{
    public class Tarefa
    {
        public Tarefa(string nome, int id, DateTime data, Estado estado)
        {
            Nome = nome;
            Id = id;
            Data = data;
            Estado = estado;
        }
        public Tarefa()
        {
            
        }
        public string Nome { get; set; }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Estado Estado { get; set; }
    }
}
