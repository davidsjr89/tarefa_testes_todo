using Todo.Model;

namespace Todo.Servico
{
    public class ProcessaServico
    {
        private List<Tarefa> _tarefas = new List<Tarefa>();
        public ProcessaServico()
        {
        }

        public bool CriarTarefa(Tarefa tarefa)
        {
            if(tarefa == null)
                return false;

            _tarefas.Add(tarefa);
            return true;
        }

        public bool AtualizaTarefa(Tarefa tarefa)
        {
            if (tarefa == null || _tarefas.Count() == 0)
                return false;

            var tarefaCarregada = _tarefas.FirstOrDefault(x =>  x.Id == tarefa.Id);
            
            if(tarefaCarregada != null)
            {
                _tarefas.Remove(tarefaCarregada);
                _tarefas.Add(tarefa);
                return true;
            }

            return false;
        }

        public bool RemoveTarefa(Tarefa tarefa)
        {
            if (tarefa == null || _tarefas.Count() == 0)
                return false;

            _tarefas.Remove(tarefa);
            return true;
        }

        public List<Tarefa> CarregaTodasAsTarefas()
        {
            return _tarefas;
        }

        public int QuantidadeTarefasPorEstadoEscolhido(Estado estado)
        {
            if(estado == null || _tarefas.Count() == 0)
                return 0;

                return _tarefas.Where(x => x.Estado == estado).Count();
        }
    }
}
